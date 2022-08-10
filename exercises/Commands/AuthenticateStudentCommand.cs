using exercises.Data.Models;
using MediatR;

namespace exercises.Commands
{
    public class AuthenticateStudentCommand : IRequest<String>
    {
        public Student Student { get; set; }
    }
}
