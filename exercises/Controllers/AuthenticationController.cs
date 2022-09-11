using AutoMapper;
using exercises.Commands;
using exercises.Data.Models;
using exercises.Queries.Students;
using exercises.Services.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync()
        {
            return Ok();
        }
    }
}
