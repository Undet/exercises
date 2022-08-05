using AutoMapper;
using exercises.Data.Models;
using exercises.Queries.Students;
using exercises.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        public Task<string> Authenticate(StudentCredentials studentCredentials)
        {
            ValidateCredentials(studentCredentials);
            string securityToken = GetToken();
            
            return Task.FromResult(securityToken);
        }

        private async void ValidateCredentials(StudentCredentials studentCredentials)
        {
            Student student = await _mediator.Send(new GetStudentByIDQuery
            {
                StudentId = studentCredentials.StudentId
            });

            bool isValid = student != null && AreValidCredentials(studentCredentials, student);

            if (!isValid)
            {
                throw new Exception("Student is not valid");
            }
        }

        private static bool AreValidCredentials(StudentCredentials studentCredentials, Student student)
        {
            return student.StudentId == studentCredentials.StudentId &&
                   student.Password == studentCredentials.Password;
        }

        private string GetToken()
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor();
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public SecurityTokenDescriptor GetTokenDescriptor()
        {
            const int expiringDays = 7;
            
            string secreetKey = _config.GetSection("SecretKey").Value;
            byte[] securityKey = Encoding.UTF8.GetBytes(secreetKey);

            var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        
    }
}
