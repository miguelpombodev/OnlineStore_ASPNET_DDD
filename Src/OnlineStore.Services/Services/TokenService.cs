
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Configuration;

namespace OnlineStore.Services.Services
{
    public class TokenService
    {
        public string GenerateToken(Customer customer)
        {
            try
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SecurityConfiguration.JWTKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[] { new Claim("user_email", customer.Email) }
                    ),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}