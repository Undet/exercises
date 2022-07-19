using MediatR;
namespace exercises.Command_and_Query.Students.Queries
{
    public class GetStudentByIDQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
