
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
        public string GenerateToken(CustomerLoginDTO customer, Customer registered_customer)
        {
            try
            {
                var validatedUserPassword = BCrypt.Net.BCrypt.Verify(customer.Password, registered_customer.Password);

                if (validatedUserPassword == false)
                {
                    throw new Exception("Password incorrect");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SecurityConfiguration.JWTKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[] { new Claim("user_email", registered_customer.Email) }
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