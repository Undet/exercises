using exercises.Data.CourseData;
using exercises.Queries.Course;
using MediatR;

namespace exercises.Handlers.Courses
{
    public class GetAllCoursesCommandHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<Data.Models.Course>>
    {
        private readonly ICourseDB _CourseDB;
        public GetAllCoursesCommandHandler(ICourseDB courseDB)
        {
            _CourseDB = courseDB;
        }

        public Task<IEnumerable<Data.Models.Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return _CourseDB.GetAll();
        }
    }
}
