using AutoMapper;
using exercises.Commands.RolesC;
using exercises.Data.Models;
using exercises.Queries.RoleQ;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exercises.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Админ")]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CourseController> _logger;

        public RoleController(IMediator mediator, ILogger<CourseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddForStudent(string role, int studentID)
        {
            var result = await _mediator.Send(new AddRoleCommand { RoleName = role, StudentId = studentID });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByID(int id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand { DeleteById = id});
            return Ok(result);
        }

    }
}
