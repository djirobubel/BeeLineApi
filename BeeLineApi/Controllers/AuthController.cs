using BeeLineApi.Commands.LoginUser;
using BeeLineApi.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeeLineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Метод регистрации пользователя.
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterUserResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsRegistered == true ? Ok(result) : BadRequest();
        }

        //Метод авторизации пользователя.
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginUserResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
