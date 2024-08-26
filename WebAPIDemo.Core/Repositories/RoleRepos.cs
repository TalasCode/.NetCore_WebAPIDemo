using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.DTO;

namespace WebAPIDemo.Core.Repositories
{
    public class RoleRepos(DbContext context) : Repository<UserRole>(context), IRoleRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)context;
        public async Task<List<UserRole>?> GetUserRolesByUserid(int id)
        {
            return await databaseServerContext.UserRoles
                .Where(u => u.UserId == id)
                .ToListAsync();
        }
        public async Task<bool> UserIsValid(int userId)
        {
            var userRole = await databaseServerContext.UserRoles.Where(u => userId == u.UserId).FirstOrDefaultAsync();
            return userRole != null;
        }
    }
}
