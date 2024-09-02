using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Request;
using WebAPIDemo.Services.Services.IServices;

namespace WebAPIDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController(IRoleService roleService) : Controller
    {
        [HttpGet("GetUserRoles/{userid}")]


        public async Task<ActionResult> GetUserRoles(int userid)
        {
            if(await roleService.UserIsValid(userid))
            {
                var userRole = await roleService.GetUserRolesWithUserId(userid);
                
                return Ok(userRole);
            }
            return BadRequest("User not Exist");

        }

    }
}
