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


namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<User>> UpdateUser(UserRequest userRequest)
        {
            try
            {
                if (userRequest.Username != null)
                {
                    var user = mapper.Map<User>(userRequest);
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
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpPost("AddRoleToUser")]

        public async Task<IActionResult> AddRoleToUser(int userId , string role)

        {
            
            var result = await userService.AddRoleToUser(userId , role);
            return Ok(result);
        }

        [HttpGet("/{username}")]
        public async Task<UserDTO> GetUserByUsername(string username)
        {

            var user = await userService.GetUserByUsername(username);
            var userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
            
        }

    }
}
