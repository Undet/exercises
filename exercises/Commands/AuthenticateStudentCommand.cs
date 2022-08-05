using exercises.Data.Models;
using MediatR;

namespace exercises.Commands
{
    public class AuthenticateStudentCommand : IRequest<String>
    {
        public StudentCredentials Credentials { get; set; }
    }
}
