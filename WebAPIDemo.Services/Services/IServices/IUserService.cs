using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserByUsername(string username);
        Task<User?> CreateUser(User user);
        Task<bool> AddRoleToUser(int roleId, string role);
         Task<User?> getUserById(int userId);
        Task<List<UserWithRoles>?> GetAllUsers();

    }
}
