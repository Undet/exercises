using exercises.Data.Models;
using exercises.DTO.Models;
using Microsoft.AspNetCore.Identity;

namespace exercises.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserLoginDTO loginDto);
        Task<string> CreateTokenAsync();

    }
}
