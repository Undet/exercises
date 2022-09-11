using AutoMapper;
using exercises.Data.Models;
using exercises.Queries.Students;
using exercises.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
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


        public AuthenticationService(IMediator mediator, IMapper mapper, IConfiguration config)
        {
            _mediator = mediator;
            _mapper = mapper;
            _config = config;
        }
        public Task<string> Authenticate(Student student)
        {
            //var roles = student.Roles;
            //var claims = new List<Claim>();

            //claims.Add(new Claim(ClaimTypes.Role, student.Role));

            //if (roles != null)
            //{
            //    foreach (var role in roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            //    }
            //}

            //string securityToken = GetToken(claims);            
            //return Task.FromResult(securityToken);
            return Task.FromResult("null");
        }               

        private Task<string> GetToken(IEnumerable<Claim> claims)
        {
            //const int expiringHours = 5;

            //string secreetKey = _config.GetSection("SecretKey").Value;
            //byte[] securityKey = Encoding.UTF8.GetBytes(secreetKey);

            //var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            //var cred = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //var securityToken = new JwtSecurityToken(
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddHours(expiringHours),
            //    signingCredentials: cred);

            //string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            //return token;
            return Task.FromResult("null");
        }

    }
}
