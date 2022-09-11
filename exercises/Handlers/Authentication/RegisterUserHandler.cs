using exercises.Services.Interfaces;
using MediatR;
using exercises.Commands.Auth;
using Microsoft.AspNetCore.Identity;

namespace exercises.Handlers.Authentication
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;
        }
        Task<IdentityResult> IRequestHandler<RegisterUserCommand, IdentityResult>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _authenticationService.RegisterUserAsync(request.RegistrationDTO);
        }
    }

}

