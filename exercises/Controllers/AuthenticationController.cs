using AutoMapper;
using exercises.DTO.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using exercises.Commands.Auth;

namespace exercises.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {

            var userResult = await _mediator.Send(new RegisterUserCommand { RegistrationDTO = userRegistration });
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO user)
        {
            var isUserValid = await _mediator.Send(new ValidateUserCommand { UserLogin = user });

            if (!isUserValid)
            { 
            return Unauthorized("User is not valid");
            }

            var token = await _mediator.Send(new CreateTokenCommand { });

            return Ok(token);
        }
    }
}
