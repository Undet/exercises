using MediatR;
namespace exercises.Queries.Students
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
