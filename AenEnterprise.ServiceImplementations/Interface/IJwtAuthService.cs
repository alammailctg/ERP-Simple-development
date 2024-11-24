using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.Messaging.Authentiations;
using AenEnterprise.ServiceImplementations.Messaging.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IJwtAuthService
    {
        Task<string> CreateUserAsync(CreateAuthUserRequest request);
        Task<GetUserRoleResponse> GetUserRoleByIdAsync(int Id);
        Task<GetUserResponse> GetUserByIdAsync(int Id);
        Task<string> CreateToken(User user);
        Task<string> GetUserByNameAsync(string name);
        Task AssignRoleToUser(int userId, List<int> roleIds);
        
        Task<string> LoginUserAsync(LoginUserRequest request);
        Task<GetAllUserResponse> GetAllUserAsync();
        Task<GetAllRolesResponse> GetAllRoleAsync();
        Task<GetUserRoleResponse> GetAllUserRoleGroupAsync();
        Task<GetUserRoleResponse> GetUserRoleByUserNameAsync();
        Task<bool> Logouts();
        Task<GetUserRoleResponse> GetAllUserRoleAsync();
        Task<GetOnlineUserResponse> GetOnlineUser();
        Task AddUserInOnline(CreateOnlineUserRequest request);
        Task DeleteUserRole(int userId);
        IEnumerable<string> GetRolesFromToken(string token);
       

    }
}

