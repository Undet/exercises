using MediatR;

namespace exercises.Commands.Studentss
{
    public class DeleteStudentByIDCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
