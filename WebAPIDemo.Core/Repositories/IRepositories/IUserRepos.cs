using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;

namespace WebAPIDemo.Core.Repositories.IRepositories;

public interface IUserRepos : IRepository<User>
{
    Task<UserDTO?> GetUserByUsername(string username);

    Task<bool> AddRoleToUser(int userId , string role);

    Task<List<UserWithRoles>?> GetAllUsers();

}
