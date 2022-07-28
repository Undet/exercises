using AutoMapper;
using exercises.Commands.Courses;
using exercises.Data.Models;
using exercises.Models.Request.Course;
using exercises.Models.Responses.Course;
using exercises.Queries.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercises.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {

        private readonly IMediator _mediator;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public CourseController(ILogger<CourseController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            IEnumerable<GetAllCoursesResDTO> result = _mapper.Map<IEnumerable<GetAllCoursesResDTO>>(courses);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCourseRequestDTO course)
        {
            var newCourse = _mapper.Map<Course>(course);

            //if student id exists
            //return ok
            //else
            //return forbiden
            //get students by id 
            await _mediator.Send(new CreateCourseCommand
            {
                Course = newCourse
            });
            var result = _mapper.Map<CreateCourseResDTO>(newCourse);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCourseRequestDTO course)
        {
            var newCourse = _mapper.Map<Course>(course);
            await _mediator.Send(new DeleteCourseCommand
            {
                Course = newCourse,
            });
            var result = _mapper.Map<DeleteCourseResDTO>(newCourse);
            return Ok(result);
        }
    }
}
