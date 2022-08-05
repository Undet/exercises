using exercises.Data.Models;

namespace exercises.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> Authenticate(StudentCredentials studentCredentials);
    }
}
