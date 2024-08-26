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
        public async Task<UserDTO?> GetUserByUsername(string username)
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
        public async Task<User> updateUser(User user)
        {

            try
            {
                await unitOfWork.Users.UpdateAsync(user);
                await unitOfWork.CommitAsync();
                return user;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
