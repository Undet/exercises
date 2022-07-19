using MediatR;
namespace exercises.Command_and_Query.Students.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
