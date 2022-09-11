using exercises.DTO.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace exercises.Commands.Auth
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public UserRegistrationDto RegistrationDTO { get; set; }
    }
}
