using exercises.Commands.RolesC;
using exercises.Data.Models;
using exercises.Data.RoleD;

using MediatR;

namespace exercises.Handlers.RoleH
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, string>
    {
        private readonly IRoleDB _RoleDB;
        public AddRoleCommandHandler(IRoleDB roleDB)
        {
            _RoleDB = roleDB;
        }

        public Task<string> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            return _RoleDB.Add(request.RoleName, request.StudentId);
        }
    }
}
