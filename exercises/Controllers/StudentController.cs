﻿using AutoMapper;
using exercises.Commands.Students;
using exercises.Commands.Studentss;
using exercises.Data.Models;
using exercises.Queries.Students;
using exercises.Request.Students;
using exercises.Respounses.Students;
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
            IEnumerable<GetAllStudentsResponsetDTO> result = _mapper.Map<IEnumerable<GetAllStudentsResponsetDTO>>(students);
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _mediator.Send(new GetStudentByIDQuery
            {
                StudentId = id
            });

            var result = _mapper.Map<GetStudentByIdResponseDTO>(student);

            return Ok(result);
        }
        [Authorize(Roles = "Староста, Админ")]
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

        [Authorize(Roles = "Админ")]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var student = await _mediator.Send(new DeleteStudentByIDCommand
            {
                StudentId = id
            });

            var result = _mapper.Map<DeleteStudentResponseDTO>(student);

            return Ok(result);
        }
        [Authorize(Roles = "Староста, Админ")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentRequestDTO studentRequest)
        {
            var student = _mapper.Map<Student>(studentRequest);
            await _mediator.Send(new UpdateStudentCommand
            {
                Student = student
            });
            var result = _mapper.Map<UpdateStudentResponseDTO>(student);
            return Ok(result);
        }

    }
}
