using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IAuthRepos
    {
        Task<string> Login(User user);
       
    }
}
