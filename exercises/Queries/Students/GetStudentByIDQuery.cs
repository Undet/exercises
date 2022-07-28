using exercises.Data.Models;
using MediatR;
namespace exercises.Queries.Students
{
    public class GetStudentByIDQuery : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}
