using exercises.Commands.Auth;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.Authentication
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, String>
    {
        private readonly IAuthenticationService _authenticationService;

        public CreateTokenHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            return _authenticationService.CreateTokenAsync();
        }
    }

}

