using exercises.Data.Models;
using MediatR;

namespace exercises.Commands.RolesC
{
    public class AddRoleCommand : IRequest<string>
    {
        public string RoleName { get; set; }
        public int StudentId { get; set; }
    }
}
