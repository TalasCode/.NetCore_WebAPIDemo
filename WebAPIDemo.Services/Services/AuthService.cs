using System;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services.IServices;

namespace WebAPIDemo.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(User user)
        {
            // Validate the user object (you may want to add more validation)
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Invalid user credentials.");
            }

            // Call the Login method from AuthRepos
            var token = await _unitOfWork.Auth.Login(user);

            // Check if the token is empty, indicating failed login
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Invalid username or password, or user is not an admin.");
            }

            return token; // Return the generated JWT token
        }
    }
}
