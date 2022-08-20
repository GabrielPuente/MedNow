using MedNow.Application.AuthenticationService;
using MedNow.Domain.Commands.User;
using MedNow.Domain.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(LoginUserCommand command)
        {
            var response = await _userService.LoginUser(command);

            if (!response.Valid)
            {
                return BadRequest(response);
            }

            var token = TokenService.GenerateToken(response.Data.Name, response.Data.Role, response.Data.Email, _configuration.GetValue<string>("Secret"));

            return Ok(new
            {
                user = response.Data,
                token
            });

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(CreateUserCommand command)
        {
            var response = await _userService.CreateUser(command);

            if (!response.Valid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("Logar")]
        [AllowAnonymous]
        public async Task<IActionResult> Logar()
        {
            var response = await _userService.LoginUser(new LoginUserCommand { Email = "gapuente96@gmail.com", Password = "123456" });

            if (!response.Valid)
            {
                return BadRequest(response);
            }

            var token = TokenService.GenerateToken(response.Data.Name, response.Data.Role, response.Data.Email, _configuration.GetValue<string>("Secret"));

            return Ok(new
            {
                user = response.Data,
                token
            });
        }

        //[HttpPut("{id:guid}/Players")]
        [HttpGet("Teste")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Teste()
        {
            return Ok(new
            {
                teste = "Teste"
            });
        }
    }
}
