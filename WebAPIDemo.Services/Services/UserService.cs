using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Repositories;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
namespace WebAPIDemo.Services.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        
        
        public async Task<List<UserWithRoles>?> GetAllUsers()
        {
            try
            {
                return await unitOfWork.Users.GetAllUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            }
        public async Task<User?> GetUserByUsername(string username)
        {
            try
            {
                return await unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<User?> CreateUser(User user)
        {
            try
            {
                await unitOfWork.Users.AddAsync(user);
                await unitOfWork.CommitAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<bool> AddRoleToUser(int userId ,  string role)
        {
            try
            {
                await unitOfWork.Users.AddRoleToUser(userId, role);
                await unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public async Task<User?> getUserById(int userId)
        {
            try
            {
                var user = await unitOfWork.Users.GetByIdAsync(userId);
                await unitOfWork.CommitAsync();
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                User? existingUser = await unitOfWork.Users.GetUserByUsername(user.Username);
                if (existingUser == null)
                {
                    throw new NotFoundException("User not found");
                }

                // Update properties
                existingUser.Fullname = user.Fullname;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Gender = user.Gender;

                // Attempt to save changes
                await unitOfWork.Users.UpdateAsync(existingUser);
                await unitOfWork.CommitAsync();

                return existingUser;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict
                Console.WriteLine("Concurrency conflict: " + ex.Message);
                // Optionally, you can implement retry logic or inform the user
                throw;
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
