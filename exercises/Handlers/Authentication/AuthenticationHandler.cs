using exercises.Commands;
using exercises.Commands.Courses;
using exercises.Data.CourseData;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticateStudentCommand, String>
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task<string> Handle(AuthenticateStudentCommand request, CancellationToken cancellationToken)
        {
            return  _authenticationService.Authenticate(request.Credentials);
        }
    }

}

