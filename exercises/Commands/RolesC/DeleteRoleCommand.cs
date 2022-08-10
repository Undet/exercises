using exercises.Data.Models;
using MediatR;

namespace exercises.Commands.RolesC
{
    public class DeleteRoleCommand : IRequest<Role>
    {
        public int DeleteById { get; set; }
    }
}
