using MediatR;

namespace exercises.Command_and_Query.StudentCQ.Commands
{
    public class DeleteStudentByIDCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
