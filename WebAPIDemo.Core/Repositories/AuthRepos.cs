using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;

namespace WebAPIDemo.Core.Repositories
{
    public class AuthRepos : IAuthRepos
    {
        private readonly DatabaseServerContext _dataBaseServerContext;
        private readonly IConfiguration _configuration;

        public AuthRepos(DatabaseServerContext dataBaseServerContext, IConfiguration configuration)
        {
            _dataBaseServerContext = dataBaseServerContext;
            _configuration = configuration;
        }

        public async Task<string> Login(User user)
        {
            // Find user by username and password hash
            var loginUser = await _dataBaseServerContext.Users
                .Where(x => x.Username == user.Username && x.PasswordHash == user.PasswordHash)
                .FirstOrDefaultAsync();

            if (loginUser == null)
            {
                return string.Empty;
            }

            // Check if the user has the admin role
            var userRole = await _dataBaseServerContext.UserRoles
                .Where(u => u.UserId == loginUser.Id && u.Role == "admin")
                .FirstOrDefaultAsync();

            if (userRole == null)
            {
                return string.Empty;
            }

            // Create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginUser.Username),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["Jwt:Audience"], 
                Issuer = _configuration["Jwt:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
