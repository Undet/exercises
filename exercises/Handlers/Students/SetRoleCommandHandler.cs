using exercises.Commands.Students;
using exercises.Data;
using exercises.Data.Models;
using MediatR;

namespace exercises.Handlers.Students
{
    public class SetRoleCommandHandler : IRequestHandler<SetRoleCommand, string>
    {
        private readonly IStudentDB _studentDB;
        public SetRoleCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }

        public Task<string> Handle(SetRoleCommand request, CancellationToken cancellationToken)
        {
           return _studentDB.SetRole(request.Student, request.Role);
        }
    }
}