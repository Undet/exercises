using exercises.Commands.Courses;
using exercises.Data.CourseData;
using MediatR;

namespace exercises.Handlers.Course
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Data.Models.Course>
    {
        private readonly ICourseDB _CourseDB;
        public DeleteCourseCommandHandler(ICourseDB courseDB)
        {
            _CourseDB = courseDB;
        }

        public Task<Data.Models.Course> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return _CourseDB.DeleteById(request.Course.CourseId);
        }
    }
}
