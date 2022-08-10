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
        public async Task<IActionResult> AuthenticateAsync(StudentCredentials studentCredentials)
        {

            Student student = await _mediator.Send(new GetStudentByIDQuery
            {
                StudentId = studentCredentials.StudentId
            });

            try
            {
                ValidateCredentials(studentCredentials, student);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            var token = _mediator.Send(new AuthenticateStudentCommand { Student = student });
            return Ok(token.Result);

        }
        private  void ValidateCredentials(StudentCredentials studentCredentials , Student student)
        {
            bool isValid = student != null && AreValidCredentials(studentCredentials, student);

            if (!isValid)
            {
                throw new Exception();
            }

        }

        private static bool AreValidCredentials(StudentCredentials studentCredentials, Student student)
        {
            return student.StudentId == studentCredentials.StudentId &&
                   student.Password == studentCredentials.Password;
        }
    }
}
