using exercises.Model;
using MediatR;

namespace exercises.Commands.Courses
{
    public class CreateCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }
    }
}
