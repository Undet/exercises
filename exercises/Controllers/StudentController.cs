using AutoMapper;
using exercises.Commands.Students;
using exercises.Commands.Studentss;
using exercises.Data.Models;
using exercises.Models;
using exercises.Queries.Students;
using exercises.Request.Students;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exercises.Controllers.StudentController
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var students = await _mediator.Send(new GetStudentsQuery());
            var result = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _mediator.Send(new GetStudentByIDQuery
            {
                StudentId = id
            });

            var result = _mapper.Map<StudentDTO>(student);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentRequestDTO student)
        {
            var newStudent = _mapper.Map<Student>(student);

            await _mediator.Send(new CreateStudentCommand
            {
                Student = newStudent
            });

            var result = _mapper.Map<StudentDTO>(newStudent);

            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var student = await _mediator.Send(new DeleteStudentByIDCommand
            {
                StudentId = id
            });
            var result = _mapper.Map<StudentDTO>(student);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentRequestDTO studentRequest)
        {
            var student = _mapper.Map<Student>(studentRequest);
            await _mediator.Send(new UpdateStudentCommand
            {
                Student = student
            });
            var result = _mapper.Map<StudentDTO>(student);
            return Ok(result);
        }
    }
}
