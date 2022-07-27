using exercises.Data.CourseData;
using exercises.Queries.Course;
using MediatR;

namespace exercises.Handlers.Courses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<exercises.Model.Course>>
    {
        private readonly ICourseDB _CourseDB;
        public GetAllCoursesQueryHandler(ICourseDB courseDB)
        {
            _CourseDB = courseDB;
        }

        public Task<IEnumerable<exercises.Model.Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return _CourseDB.GetAll();
        }
    }
}
