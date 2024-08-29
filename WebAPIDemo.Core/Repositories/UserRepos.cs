
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;


namespace WebAPIDemo.Core.Repositories
{
    internal class UserRepos(DbContext context) : Repository<User>(context), IUserRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;
        public async Task<List<UserWithRoles>?> GetAllUsers()
        {
            return await databaseServerContext.Users
                .Select(u => new UserWithRoles
                {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.Fullname,
                    DateOfBirth = u.DateOfBirth,
                    Gender = u.Gender,
                    PasswordHash = u.PasswordHash,
                    Roles = u.UserRoles!.Select(r => new RoleDTO
                    {
                        Id = r.Id,
                        UserId = r.Id,
                        Role = r.Role,
                    }).ToList()

                }).ToListAsync();
        }
        public async Task<User?> GetUserByUsername(string username)
        {
            return await databaseServerContext.Users
                .Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<bool> AddRoleToUser(int userId, string role)
        {
            var user = await databaseServerContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            var exitUserRole = await databaseServerContext.UserRoles.Where(r => r.Role == role && r.UserId == userId).FirstOrDefaultAsync();
            if (exitUserRole != null) { return false; }
            var _role = new UserRole
            {
                UserId = userId,
                Role = role,
            };
            user.UserRoles.Add(_role);
            databaseServerContext.Users.Update(user);
            await databaseServerContext.SaveChangesAsync();
            return true;


        }
    }
}
