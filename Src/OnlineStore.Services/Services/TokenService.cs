
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Configuration;

namespace OnlineStore.Services.Services
{

    public class TokenService : ITokenService
    {

        public string GenerateToken(Customer customer)
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

        public string DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var splittedToken = token.Split(" ").First(c => c != "Bearer");

            var decodedToken = tokenHandler.ReadToken(splittedToken);

            var tokenInfo = decodedToken as JwtSecurityToken;
            return tokenInfo.Claims.First(claim => claim.Type == "user_email").Value;

        }
    }
}