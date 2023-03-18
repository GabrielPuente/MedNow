using MedNow.Application.AuthenticationService;
using MedNow.Application.Commands.User;
using MedNow.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(LoginUserCommand command)
        {
            var response = await _userService.LoginUser(command);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            var token = TokenService.GenerateToken(response.Data, _configuration.GetValue<string>("Secret"));

            return Ok(new
            {
                userName = response.Data.Name,
                userEmail = response.Data.Email,
                token
            });

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var response = await _userService.CreateUser(command);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            var response = await _userService.LoginUser(new LoginUserCommand { Email = "gapuente96@gmail.com", Password = "123456" });

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            var token = TokenService.GenerateToken(response.Data, _configuration.GetValue<string>("Secret"));

            return Ok(token);
        }

        ////[HttpPut("{id:guid}/Players")]
        //[HttpGet("Teste")]
        ////[Authorize(Roles = "Coach")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Teste()
        //{
        //    return Ok(new
        //    {
        //        id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Hash).Value,
        //        name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
        //        email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
        //        role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value,
        //    });
        //}
    }
}
