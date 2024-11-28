using AenEnterprise.DataAccess.LicenseActivator;
using AenEnterprise.FrontEndMvc.Models.LicenseDto;
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/License")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        [Authorize("admin")]
        [Route("generate")]
        [HttpPost]
        public IActionResult GenerateLicense([FromBody] LicenseGenerationRequest request)
        {
            if (string.IsNullOrEmpty(request.SecretKey) || string.IsNullOrEmpty(request.ClientName) || request.StartDate == null || request.ExpiryDate == null)
            {
                return BadRequest(new { Message = "All fields are required" });
            }

            var generator = new LicenseGenerator(request.SecretKey);
            var licenseKey = generator.GenerateLicenseKey(request.ClientName, request.StartDate.Value, request.ExpiryDate.Value);

            return Ok(new { LicenseKey = licenseKey });
        }


        [Route("validate")]
        [HttpPost]
        public IActionResult ValidateLicense([FromBody] LicenseValidationRequest request)
        {
            if (string.IsNullOrEmpty(request.SecretKey) || string.IsNullOrEmpty(request.LicenseKey))
            {
                return BadRequest(new { Message = "All fields are required" });
            }

            var validator = new LicenseValidator(request.SecretKey);

            if (validator.ValidateLicenseKey(request.LicenseKey, out var claimsPrincipal))
            {
                var clientName = claimsPrincipal.FindFirst("ClientName")?.Value;
                var startDate = claimsPrincipal.FindFirst("StartDate")?.Value;
                var expiryDate = claimsPrincipal.FindFirst("ExpiryDate")?.Value;

                return Ok(new
                {
                    Message = "License is valid",
                    ClientName = clientName,
                    StartDate = startDate,
                    ExpiryDate = expiryDate,
                    RedirectUrl = "http://localhost:4200/admin/create-sales-order" // Specify the redirect URL here
                });
            }

            return Unauthorized(new { Message = "Invalid or expired license key" });
        }
    }
     
}

