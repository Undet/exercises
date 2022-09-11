using exercises.Controllers;
using exercises.DTO.Models;
using MediatR;

namespace exercises.Commands.Auth
{
    public class ValidateUserCommand : IRequest<bool>
    {
        public UserLoginDTO UserLogin { get; set; }

    }
}
