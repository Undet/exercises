using AutoMapper;
using exercises.Controllers;
using exercises.Data.Models;
using exercises.DTO.Models;
using exercises.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace exercises.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly UserManager<Student> _userManager;
        private Student _student;


        public AuthenticationService(IMediator mediator, IMapper mapper, IConfiguration config, UserManager<Student> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
        }               

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration)
        {
            
            var user = _mapper.Map<Student>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            return result;
        }

        public async Task<bool> ValidateUserAsync(UserLoginDTO loginDto)
        {
            _student = await _userManager.FindByNameAsync(loginDto.UserName);
            var result = _student != null && await _userManager.CheckPasswordAsync(_student, loginDto.Password);
            return result;
        }

        public async Task<string> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _config.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _student.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_student);
            roles.Add("admin");
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
