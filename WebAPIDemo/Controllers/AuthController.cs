using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Services;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Request;

namespace WebAPIDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            try
            {
                var user = _mapper.Map<User>(login);
                var token = await _authService.Login(user);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
