using MediatR;

namespace exercises.Command_and_Query.Students.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }
    }
}
