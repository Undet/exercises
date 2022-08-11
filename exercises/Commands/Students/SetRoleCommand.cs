using exercises.Data.Models;
using MediatR;

namespace exercises.Commands.Students
{
    public class SetRoleCommand : IRequest<string>
    {
        public Student Student { get; set; }
        public string Role { get; set; }
    }
}
