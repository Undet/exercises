using AutoMapper;
using exercises.Commands.Students;
using exercises.Commands.Studentss;
using exercises.Queries.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercises.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger, IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var result = await _mediator.Send(new GetStudentByIDQuery { 
            Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                SecondName = student.SecondName,
                Password = student.Password
            };

            var result = await _mediator.Send(new CreateStudentCommand { 
             Student = newStudent
            });

            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _mediator.Send(new DeleteStudentByIDCommand {
            Id = id
            });

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {          

            var result = await _mediator.Send(new UpdateStudentCommand
            {
                Student = student
            }) ;

            return Ok(result);
        }

    }
}
