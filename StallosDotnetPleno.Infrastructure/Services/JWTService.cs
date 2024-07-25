using StallosDotnetPleno.Application.Interfaces.Services;
using StallosDotnetPleno.Domain.Models.Customer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace StallosDotnetPleno.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly string JWTSecret = Environment.GetEnvironmentVariable("JWT_SECRET")!;

        public string Generate(CustomerModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JWTSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim("Id", model.Id.ToString()),
                    new Claim( "Name", model.Name),
                    new Claim( "Document", model.Document),
                ]),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}