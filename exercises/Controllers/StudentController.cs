using exercises.Command_and_Query.StudentCQ.Commands;
using exercises.Command_and_Query.Students.Commands;
using exercises.Command_and_Query.Students.Queries;
using exercises.Data;
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

        public StudentController(ILogger<StudentController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
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
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                SecondName = student.SecondName
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
            var newStudent = new Student
            {
                Name = student.Name,
                SecondName = student.SecondName
            };
            var result = await _mediator.Send(new UpdateStudentCommand
            {
                Student = newStudent
            }) ;

            return Ok(result);
        }

    }
}
