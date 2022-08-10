using exercises.Commands.RolesC;
using exercises.Data.Models;
using exercises.Data.RoleD;
using MediatR;

namespace exercises.Handlers.RoleH
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Role>
    {
        private readonly IRoleDB _RoleDB;
        public DeleteRoleHandler(IRoleDB roleDB)
        {
            _RoleDB = roleDB;
        }

        public Task<Role> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return _RoleDB.DeleteById(request.DeleteById);
        }
    }
}
