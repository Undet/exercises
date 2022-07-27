using MediatR;

namespace exercises.Queries.Course
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<exercises.Model.Course>>
    {
    }
}
