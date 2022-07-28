using exercises.Commands.Courses;
using exercises.Data.CourseData;
using MediatR;

namespace exercises.Handlers.Courses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Data.Models.Course>
    {
        private readonly ICourseDB _CourseDB;
        public CreateCourseCommandHandler(ICourseDB courseDB)
        {
            _CourseDB = courseDB;
        }

        public Task<Data.Models.Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            return _CourseDB.Add(request.Course);
        }
    }
}
