using exercises.Model;
using MediatR;

namespace exercises.Commands.Courses
{
    public class DeleteCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }
    }
}
