using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.LicenseActivator
{
    public class LicenseValidator
    {
        private readonly string _secretKey;

        public LicenseValidator(string secretKey)
        {
            _secretKey = secretKey;
        }

        public bool ValidateLicenseKey(string licenseKey, out ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal = null;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = System.Text.Encoding.UTF8.GetBytes(_secretKey);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true, // Checks both NotBefore and Expiry
                    ClockSkew = TimeSpan.Zero
                };

                claimsPrincipal = tokenHandler.ValidateToken(licenseKey, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
