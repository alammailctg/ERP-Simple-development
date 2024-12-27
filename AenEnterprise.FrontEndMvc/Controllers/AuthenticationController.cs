using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.FrontEndMvc.Models.Authentications;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.Authentiations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthService _jwtAuthService;
        //private readonly SmsService _smsService;
        

        public AuthenticationController(JwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
           
        }

        [Route("isauth")]
        [HttpGet]
        public IActionResult CheckAuthorization()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Ok("User is authenticated");
            }
            return Unauthorized("User is not authenticated");
        }



        [Route("CreateUser")]
        [HttpPost]
        public async Task<ActionResult> Registration([FromBody] CreateAuthUserRequest formRequest)
        {

            CreateUserResponse response = new CreateUserResponse();
            CreateAuthUserRequest request = new CreateAuthUserRequest()
            {
                UserName = formRequest.UserName,
                Password = formRequest.Password
            };
           string message= await _jwtAuthService.CreateUserAsync(request);
            return Ok(message);
        }

        [Route("LoginUser")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginUserRequestForm formRequest)
        {
            LoginUserRequest request = new LoginUserRequest()
            {
                UserName = formRequest.UserName,
                Password = formRequest.Password
            };
            var response= await _jwtAuthService.LoginUserAsync(request);
            return Ok(response);
        }

        //[Route("Sendotp")]
        //[HttpPost]
        //public async Task<ActionResult> SendOtp()
        //{
        //    string mobileNumber = "01789109271"; // Example mobile number in Bangladesh
        //    string otp = "123456"; // Example OTP
        //    await  _vonageSMSService.SendOtpAsync(mobileNumber, otp);
        //    return Ok("OTP send to your mobile");
        //}




        [Route("GetRoleFromClaim")]
        [HttpGet]
        public async Task<IActionResult> GetRoleFromClaim([FromQuery] string token)
        {
            var roles =_jwtAuthService.GetRolesFromToken(token); // Get roles from the token
            return Ok(roles);
        }



        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Route("GetOnlineUsers")]
        [HttpGet]
        public async Task<IActionResult> GetOnlineUsers()
        {
            var onlineUsers =await _jwtAuthService.GetOnlineUser();
            return Ok(onlineUsers);
        }


        [Route("GetUserName")]
        [HttpGet]
        public async Task<ActionResult> GetCurrentName()
        {
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            
            if (!string.IsNullOrEmpty(usernameClaim))
            {
                return Ok(usernameClaim);
            }

            return NotFound("User not found");
        }

        [Route("GetUser")]
        [HttpPost]
        public async Task<ActionResult> GetGetUserByName(string name)
        { 
            var response = await _jwtAuthService.GetUserByNameAsync(name);
            if (response == null)
            {
                return NotFound();  // Handle case where the user is not found
            }
            return Ok(response);
        }

        
        [Route("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllUserList()
        {
            var response = await _jwtAuthService.GetAllUserAsync();
            if (response == null)
            {
                return NotFound();  // Handle case where the user is not found
            }
            return Ok(response);
        }




        [Route("GetUserRoleByUserName")]
        [HttpGet]
        public async Task<ActionResult> GetGetUserRoleByUserName()
        {
            var response = await _jwtAuthService.GetUserRoleByUserNameAsync();
            if (response == null)
            {
                return NotFound();  // Handle case where the user is not found
            }
            return Ok(response);
        }

        [Route("GetAllUserRoles")]
        [HttpGet]
        public async Task<ActionResult> GetAllUserRole()
        {
            var response = await _jwtAuthService.GetAllUserRoleAsync();
            if (response == null)
            {
                return NotFound();  // Handle case where the user is not found
            }
            return Ok(response);
        }

        [Route("GetToken")]
        [HttpGet]
        public async Task<IActionResult> GetRefreshToken()
        {
            var token = await _jwtAuthService.GetRefreshToken();
            return Ok(token);
        }



        //[Route("GetUserRole")]
        //[HttpGet]
        //public async Task<IActionResult> GetUserRoleByUserId([FromQuery] int Id)
        //{
        //    var userRole = await _jwtAuthService.GetUserRoleByIdAsync(Id);
        //    return Ok(userRole);
        //}

        [Route("AssignRole")]
        [HttpPost] // Changed from HttpGet to HttpPost
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestForm request) // Assuming you create a DTO
        {
            if (request == null || request.RoleIds == null || request.RoleIds.Count == 0)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                await _jwtAuthService.AssignRoleToUser(request.UserId, request.RoleIds);
                return Ok("Roles assigned successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return the error message
            }
        }

        

        [HttpPost("logout")]
        public async Task<IActionResult> PostLogout()
        {
            bool result = await _jwtAuthService.Logouts();

            if (result)
            {
                return Ok(new { message = "Successfully logged out." });
            }
            else
            {
                return StatusCode(500, new { message = "Error during logout." });
            }
        }

        [Route("GetUserRole")]
        [HttpGet]
        public async Task<IActionResult> GetUserRoleByUserIdAsync([FromQuery] int Id)
        {
           var response= await _jwtAuthService.GetUserRoleByIdAsync(Id);
            return Ok(response); 
        }
        



    }
}
