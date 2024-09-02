using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;

using WebAPIDemo.Request;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Services.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using WebAPIDemo.Services;
using Microsoft.AspNetCore.Authorization;


namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService, IMapper mapper) : Controller

    {
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> Get()
        {
            var users = await userService.GetAllUsers();
            
            return Ok(users);
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<User>> CreateUser(UserRequest userRequest)
        {
            if (userRequest == null || string.IsNullOrEmpty(userRequest.Username))
            {
                return BadRequest("Please provide a valid username.");
            }
            var existingUser = await userService.GetUserByUsername(userRequest.Username);

            if (existingUser != null)

            {
                return BadRequest($" {userService.GetUserByUsername(userRequest.Username).Result}The username '{userRequest.Username}' is already used.");
            }

            var newUser = mapper.Map<User>(userRequest);
            await userService.CreateUser(newUser);

            return Ok(newUser);
        }
        [HttpPost("/updateUser")]
        public async Task<ActionResult<User>> UpdateUser(int id ,UserRequest userRequest)
        {
            
                if (userRequest.Username != null)
                {
                    var user = mapper.Map<User>(userRequest);
                user.Id = id;
                    var updatedUser = await userService.UpdateUser(user);
                    if (updatedUser != null)
                    {
                        return Ok(updatedUser);
                    }
                    else
                    {
                        return NotFound("User not found");
                    }
                }
                else
                {
                    return BadRequest("Username is required");
                }
            }
            
        



        [HttpPost("AddRoleToUser")]

        public async Task<IActionResult> AddRoleToUser(int userId , string role)

        {
            
            var result = await userService.AddRoleToUser(userId , role);
            return Ok(result);
        }

        [HttpGet("/getUserByUsername")]
        public async Task<ActionResult<UserRequest>> GetUserByUsername(string username)
        {

            User? user = await userService.GetUserByUsername(username);
            if (user == null) Console.WriteLine("Username not found");
            var userRequest = mapper.Map<UserRequest>(user);
            return Ok(userRequest);
            
        }

    }
}
