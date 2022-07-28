using exercises.Data.Models;
using MediatR;

namespace exercises.Commands.Students
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }
    }
}
