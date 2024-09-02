using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Login(User user);
    }
}
