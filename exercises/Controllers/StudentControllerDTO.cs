using AutoMapper;
using exercises.Commands.Students;
using exercises.Commands.Studentss;
using exercises.Queries.Students;
using exercises.Request.Students;
using exercises.Respounses.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercises.DTO.ControllersDTO
{
    [ApiController]
    [Route("[controller]")]
    public class StudentControllerDTO : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentControllerDTO> _logger;
        private readonly IMapper _mapper;

        public StudentControllerDTO(ILogger<StudentControllerDTO> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            IEnumerable<GetAllStudentsResponsetDTO> result = _mapper.Map<IEnumerable<GetAllStudentsResponsetDTO>>(students);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var student = await _mediator.Send(new GetStudentByIDQuery
            {
                Id = id
            });

            var result = _mapper.Map<GetStudentByIdResponseDTO>(student);

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

            var result = _mapper.Map<CreateStudentResponseDTO>(newStudent);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {            
            var student = await _mediator.Send(new DeleteStudentByIDCommand
            {
                Id = id
            });

            var result = _mapper.Map<DeleteStudentResponseDTO>(student);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            var stud = await _mediator.Send(new UpdateStudentCommand
            {
                Student = student
            });
            var result = _mapper.Map<UpdateStudentResponseDTO>(student);
            return Ok(result);
        }

    }
}
