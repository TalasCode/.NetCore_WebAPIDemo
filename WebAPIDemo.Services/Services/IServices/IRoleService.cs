using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IRoleService
    {
        Task<List<UserRole>?> GetUserRolesWithUserId(int userId);
        Task<bool> UserIsValid(int userId);
    }
}
