using exercises.Commands.Courses;
using exercises.Model;
using exercises.Data.CourseData;
using MediatR;

namespace exercises.Handlers.Courses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, exercises.Model.Course>
    {
        private readonly ICourseDB _CourseDB;
        public CreateCourseCommandHandler(ICourseDB courseDB)
        {
            _CourseDB = courseDB;
        }

        public Task<exercises.Model.Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            return _CourseDB.Add(request.Course);
        }
    }
}
