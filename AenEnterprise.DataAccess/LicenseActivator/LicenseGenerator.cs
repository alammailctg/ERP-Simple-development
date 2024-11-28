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
    public class LicenseGenerator
    {
        private readonly string _secretKey;
        public LicenseGenerator(string secretKey)
        {
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            {
                throw new ArgumentException("Secret key must be at least 32 characters long.");
            }

            _secretKey = secretKey;
        }
        public string GenerateLicenseKey(string clientName, DateTime startDate, DateTime expiryDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("ClientName", clientName),
                    new Claim("StartDate", startDate.ToString("o")),
                    new Claim("ExpiryDate", expiryDate.ToString("o"))
                }),
                NotBefore = startDate, // The token is valid only after this date
                Expires = expiryDate, // Expiration date
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
