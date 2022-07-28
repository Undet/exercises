using exercises.Data.Models;
using MediatR;

namespace exercises.Commands.Studentss
{
    public class DeleteStudentByIDCommand : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}
