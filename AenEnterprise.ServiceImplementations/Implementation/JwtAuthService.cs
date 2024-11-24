using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.Authentiations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.CookieStorage;
using System.Net.Http.Headers;
using AenEnterprise.ServiceImplementations.Mapping;
using AenEnterprise.ServiceImplementations.Messaging.Users;
using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Azure;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Connections.Features;
using AenEnterprise.ServiceImplementations.Implementation.JwtTwoFactorAuth;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICookieImplementation _cookieImplementation;
        private readonly AenEnterpriseDbContext _context;
        private readonly IOnlineUserRepository _onlineUserRepository;
        

        public JwtAuthService(IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            IUnitOfWork uow,
            IConfiguration configuration,
            IMapper mapper,
            ICookieImplementation cookieImplementation,
            AenEnterpriseDbContext context,
            IOnlineUserRepository onlineUserRepository
            )
             
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _uow = uow;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
            _cookieImplementation = cookieImplementation;
            _onlineUserRepository = onlineUserRepository;
        }


        public async Task AddUserInOnline(CreateOnlineUserRequest request)
        {
            OnlineUser onlineUser = new OnlineUser();
            onlineUser.ExpirationTime = request.ExpirationTime;
            onlineUser.Username = request.Username;
            await _onlineUserRepository.AddAsync(onlineUser);
            _uow.SaveAsync();
        }

        public async Task<GetOnlineUserResponse> GetOnlineUser()
        {
            GetOnlineUserResponse response = new GetOnlineUserResponse();
            IEnumerable<OnlineUser> onlineUsers = await _onlineUserRepository.FindAllAsync();
            response.OnlineUsers = onlineUsers.ConvertToOnlineUserViews(_mapper);
            return response;
        }

        public async Task<string> CreateUserAsync(CreateAuthUserRequest request)
        {
            string token;
            var users = await _userRepository.FindAllAsync();
            var uniqueUserNames = new HashSet<string>();
            var duplicates = new List<string>();

            //This loop for add in hashset
            foreach (var item in users)
            {
                if (!uniqueUserNames.Add(item.Username))
                {
                    duplicates.Add(item.Username);
                }
            }

            // This for check in hashset
            if (!uniqueUserNames.Add(request.UserName))
            {
                return token = $"The user '{request.UserName}' already exists.";
            }
            else
            {
                var hmac = new HMACSHA512();
                User newUser = new User()
                {
                    Username = request.UserName,
                    Password = request.Password,
                    PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password)),
                    TokenExpires = DateTime.Today,
                    TokenCreated = DateTime.Today
                };
                await _userRepository.AddAsync(newUser);
                await _uow.SaveAsync();
                token = await CreateToken(newUser);
            }
            return token;
            //User user = await _userRepository.GetByStringAsync(u => u.Username == request.UserName);
        }
        public async Task<string> CreateToken(User user)
        {
            // Initialize claims with basic user information
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
               expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<string> GetUserByNameAsync(string name)
        {
            User user = await _userRepository.GetByStringAsync(u => u.Username == name);
            string token = await CreateToken(user);
            return token;
        }

        public async Task<string> LoginUserAsync(LoginUserRequest request)
        {
            var jwt = string.Empty; // Declare jwt outside the if block to avoid scope issues

            var users = await _userRepository.FindAllAsync();
            
            HashSet<string> uniqueUserNames = new HashSet<string>();
            List<string> duplicates = new List<string>();

            // Loop through existing users and add usernames to HashSet
            foreach (var item in users)
            {
                if (!uniqueUserNames.Add(item.Username))
                {
                    duplicates.Add(item.Username);
                }
            }

            foreach (var item in users)
            {
                if (!uniqueUserNames.Add(item.Password))
                {
                    duplicates.Add(item.Password);
                }
            }

            // Check if the new request's username already exists in the HashSet
            if (uniqueUserNames.Contains(request.UserName) && uniqueUserNames.Contains(request.Password))
            {

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, request.Id.ToString()),
                    new Claim(ClaimTypes.Name, request.UserName)
                };
                // Get UserRole and assign to Claim
                IEnumerable<UserRole> userRoles = await _userRoleRepository.IncludeOfUserRoleForUserName(request.UserName);
                var uroles = userRoles.Select(ur => ur.ConvertToUserRoleView(_mapper)).ToList();

                // Add roles to claim
                foreach (var item in uroles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                }

                // Create Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(24),
                    signingCredentials: creds);

                //Generate Token
                jwt = new JwtSecurityTokenHandler().WriteToken(token);
 
                _cookieImplementation.Set(CookieDataKey.UserName.ToString(), request.UserName, 1, true, false);
                _cookieImplementation.Set(CookieDataKey.Token.ToString(), jwt, 1, true, false);
            }
            else
            {
                // Username does not exist, deny access
               jwt= "You are not registared to login.";
            }
  
            return jwt; // Return the JWT token
        }

 



        //Tiwilo acc email- aenprogrammingsource@gmail.com, password - Bangladesh@1234##
        //MEP4Y1KXJYDXJ8LEU8Y8S1FS




        public IEnumerable<string> GetRolesFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(token)) // Check if the token is valid
            {
                var jwtToken = handler.ReadJwtToken(token); // Read the JWT token

                // Retrieve roles from claims
                var roles = jwtToken.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                return roles; // Return list of roles
            }

            return Enumerable.Empty<string>(); // Return an empty list if token is invalid
        }


        public async Task<string> GetRefreshToken()
        {
            string userName = _cookieImplementation.Get(CookieDataKey.UserName.ToString());
            GetUserResponse response = new GetUserResponse();
            if (userName != null)
            {
                User user = await _userRepository.GetByStringAsync(u => u.Username == userName);
                response.User = user.ConvertToUserView(_mapper);
            }
                
            return response.User.RefreshToken;
        }

 
        public async Task UpdateUser(UpdateUserRequest request)
        {
            // Retrieve the user by username
            User userFound = await _userRepository.GetUserByUsernameAsync(request.Username);

            if (userFound == null)
            {
                throw new Exception("User not found");
            }

            // Update the RefreshToken or any other properties
            userFound.RefreshToken = request.RefreshToken;

            // Save changes
            await _userRepository.UpdateAsync(userFound);
            await _uow.SaveAsync();
        }


        //public async Task AssignRoleToUser(int userId, List<int> roleIds)
        //{
        //    User user = await _userRepository.GetByIdAsync(userId);
        //    if (user == null)
        //    {
        //        throw new Exception("User not found.");
        //    }

        //    foreach (var roleId in roleIds)
        //    {
        //        Role role = await _roleRepository.GetByIdAsync(roleId);
        //        if (role == null)
        //        {
        //            throw new Exception($"Role with ID {roleId} not found.");
        //        }

        //        UserRole userRoleForDelete = await _context.UserRoles.FindAsync(userId, roleId);

        //        UserRole newUserRole = new UserRole
        //        {
        //            UserId = user.Id, // Set UserId
        //            RoleId = role.Id   // Set RoleId
        //        };

        //        if(userRoleForDelete == null)
        //        {

        //            await _userRoleRepository.AddAsync(newUserRole);
        //        }
        //        else if(userRoleForDelete!=null)
        //        {
        //            await _userRoleRepository.RemoveAsync(userRoleForDelete);
        //            await _userRoleRepository.AddAsync(newUserRole);
        //        }
        //        else
        //        {
        //            throw new Exception($"No change found");
        //        }
        //    }

        //    await _uow.SaveAsync(); // Save changes
        //} 


        public async Task AssignRoleToUser(int userId, List<int> roleIds)
        {
            // Fetch the user by userId
            User user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Fetch current roles assigned to the user
            var currentUserRoles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToListAsync();

            // Get the list of currently assigned RoleIds
            var currentRoleIds = currentUserRoles.Select(ur => ur.RoleId).ToList();

            // Find roles to be added (new roles in roleIds but not in currentRoleIds)
            var rolesToAdd = roleIds.Except(currentRoleIds).ToList();

            // Find roles to be removed (current roles not in the new roleIds list)
            var rolesToRemove = currentRoleIds.Except(roleIds).ToList();

            // Add new roles that are in the new roleIds but not in currentUserRoles
            foreach (var roleId in rolesToAdd)
            {
                var role = await _roleRepository.GetByIdAsync(roleId);
                if (role == null)
                {
                    throw new Exception($"Role with ID {roleId} not found.");
                }

                UserRole newUserRole = new UserRole
                {
                    UserId = user.Id, // Set UserId
                    RoleId = role.Id  // Set RoleId
                };

                await _userRoleRepository.AddAsync(newUserRole);
            }

            // Remove roles that are no longer in the roleIds list
            foreach (var roleId in rolesToRemove)
            {
                var userRoleToRemove = currentUserRoles.FirstOrDefault(ur => ur.RoleId == roleId);
                if (userRoleToRemove != null)
                {
                    await _userRoleRepository.RemoveAsync(userRoleToRemove);
                }
            }

            // Save the changes to the database
            await _uow.SaveAsync();
        }


        public async Task DeleteUserRole(int userId)
        {
            UserRole userRole= await _userRoleRepository.GetByIdAsync(userId);
            await _userRoleRepository.RemoveAsync(userRole);
            await _uow.SaveAsync();
        }
             
        
        public async Task<GetAllUserResponse> GetAllUserAsync()
        {
            GetAllUserResponse response = new GetAllUserResponse();
            IEnumerable<User> users = await _userRepository.FindAllAsync();
            response.users = users.ConvertToUserViews(_mapper);
            return response;
        }

        public async Task<GetUserRoleResponse> GetUserRoleByIdAsync(int Id)
        {
            GetUserRoleResponse response = new GetUserRoleResponse();
            IEnumerable<UserRole> userRoles = await _userRoleRepository.IncludeOfUserRole(Id);
            response.UserRoles = userRoles.Select(ur => ur.ConvertToUserRoleView(_mapper)).ToList();
            return response;
        }

        public async Task<GetUserRoleResponse> GetUserRoleByUserNameAsync()
        {
            string userName = _cookieImplementation.Get(CookieDataKey.UserName.ToString());
            GetUserRoleResponse response = new GetUserRoleResponse();
            IEnumerable<UserRole> userRoles = await _userRoleRepository.IncludeOfUserRoleForUserName(userName);

            // Convert to UserRoleView list
            var userRoleViews = userRoles.Select(ur => ur.ConvertToUserRoleView(_mapper)).ToList();

            // Group by UserName
            var groupedByUserRoles = userRoleViews
                .GroupBy(ur => ur.UserName)
                .Select(group => new UserRoleView
                {
                    UserName = group.Key,
                    RoleNames = group.Select(ur => ur.RoleName).ToList() // This now works
                })
                .ToList();

            // Set the grouped roles to response
            response.UserRoles = groupedByUserRoles;

            return response;
        }

        public async Task<GetUserRoleResponse> GetAllUserRoleGroupAsync()
        {
            string userName = _cookieImplementation.Get(CookieDataKey.UserName.ToString());
            GetUserRoleResponse response = new GetUserRoleResponse();
            IEnumerable<UserRole> userRoles = await _userRoleRepository.IncludeOfUserRoleForAllUser();

            // Convert to UserRoleView list
            var userRoleViews = userRoles.Select(ur => ur.ConvertToUserRoleView(_mapper)).ToList();

            // Group by UserName
            var groupedByUserRoles = userRoleViews
                .GroupBy(ur => ur.UserName)
                .Select(group => new UserRoleView
                {
                    UserName = group.Key,
                    RoleNames = group.Select(ur => ur.RoleName).ToList() // This now works
                })
                .ToList();

            // Set the grouped roles to response
            response.UserRoles = groupedByUserRoles;

            return response;
        }



        public async Task<GetUserResponse> GetUserByIdAsync(int Id)
        {
            GetUserResponse response = new GetUserResponse();
            User user =await _userRepository.GetByIdAsync(Id);
            response.User = user.ConvertToUserView(_mapper);
            return response;
        }

        public async Task<GetAllRolesResponse> GetAllRoleAsync()
        {
            GetAllRolesResponse response = new GetAllRolesResponse();
            IEnumerable<Role> rolse = await _roleRepository.FindAllAsync();
            response.Roles = rolse.ConvertToRoleViews(_mapper);
            return response;
        }

        public async Task<bool> Logouts()
        {
            _cookieImplementation.Remove(CookieDataKey.UserName.ToString());
            return true;
            
        }

        public async Task<GetUserRoleResponse> GetUserRoleByUserIdAsync(int Id)
        {
            GetUserRoleResponse response = new GetUserRoleResponse();
            UserRole userRole = await _userRoleRepository.GetByIdAsync(Id);
            response.UserRole = userRole.ConvertToUserRoleView(_mapper);
            return response;
        }

        public Task<GetUserRoleResponse> GetAllUserRoleAsync()
        {
            throw new NotImplementedException();
        }
    }
}



