using Microservices.Common.Commands;
using Microservices.Services.Identity.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.Identity.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)

            => Json(await _userService.LoginAsync(command.Email, command.Password));


    }
}
