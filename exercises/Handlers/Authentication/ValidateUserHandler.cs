using exercises.Commands.Auth;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.Authentication
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserCommand, bool>
    {
        private readonly IAuthenticationService _authenticationService;

        public ValidateUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        Task<bool> IRequestHandler<ValidateUserCommand, bool>.Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            return _authenticationService.ValidateUserAsync(request.UserLogin);
        }
    }

}

