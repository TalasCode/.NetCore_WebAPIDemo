using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories
    ;
using WebAPIDemo.Core.DTO;
namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IRoleRepos : IRepository<UserRole>
    {
        Task<List<UserRole>?> GetUserRolesByUserid(int id);
        Task<bool> UserIsValid(int userId);
    }
}
