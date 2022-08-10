using exercises.Data.Models;
using exercises.Data.RoleD;
using exercises.Queries.RoleQ;
using MediatR;

namespace exercises.Handlers.RoleH
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
    {
        private readonly IRoleDB _RoleDB;
        public GetAllRolesQueryHandler(IRoleDB roleDB)
        {
            _RoleDB = roleDB;
        }

        public Task<IEnumerable<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return _RoleDB.GetAll();
        }
    }
}
