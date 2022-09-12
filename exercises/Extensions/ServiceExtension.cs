using exercises.Data;
using exercises.Data.CourseData;
using exercises.Data.Models;
using exercises.Services.Implementations;
using exercises.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace exercises.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentDB, StudentDB>();
            services.AddScoped<ICourseDB, CourseDB>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IWeekendCalendarService, WeekendCalendarService>();
        }
        public static void ConfigureDataBaseContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<AppDBContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["JwtConfig:secretKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Student, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDBContext>()
            .AddDefaultTokenProviders();
        }
        public static void ConfigureMapping(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.GetExecutingAssembly());
        public static void ConfigureMediatr(this IServiceCollection services)
            => services.AddMediatR(Assembly.GetExecutingAssembly());
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Student API",
                    Version = "v0.1",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

    }
}
