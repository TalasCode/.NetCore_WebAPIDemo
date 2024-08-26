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
    public class RoleService(IUnitOfWork unitOfWork) : IRoleService
    {
        public async Task<List<UserRole>?> GetUserRolesWithUserId(int userId)
        {
            try
            {
                var roles = await unitOfWork.Roles.GetUserRolesByUserid(userId);
                return roles ?? new List<UserRole>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw; // Rethrow the exception
            }
        }
        public async Task<bool> UserIsValid(int userid)
        {
            try
            {
                return await unitOfWork.Roles.UserIsValid(userid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.StackTrace);
            }

    }
}
}
