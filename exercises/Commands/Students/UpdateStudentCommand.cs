using MediatR;

namespace exercises.Commands.Students
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }
    }
}
