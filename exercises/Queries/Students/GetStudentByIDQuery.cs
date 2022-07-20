using MediatR;
namespace exercises.Queries.Students
{
    public class GetStudentByIDQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
