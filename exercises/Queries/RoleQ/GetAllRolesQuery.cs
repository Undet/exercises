using exercises.Data.Models;
using MediatR;

namespace exercises.Queries.RoleQ
{
    public class GetAllRolesQuery : IRequest<IEnumerable<Role>>
    {
    }
}
