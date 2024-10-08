using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure
           (this IServiceCollection services, IConfiguration configuration)

        {
            //đăng kí database
            services.AddDbContext<FlightSystemDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
            // cấu hình jwt 
            services.AddAuthentication(options =>
            {
                // Xác định phương thức xác thực là JWT Bearer
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // Xác định các tham số xác thực token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Kiểm tra Issuer có hợp lệ không
                    ValidateAudience = true, // Kiểm tra Audience có hợp lệ không
                    ValidateLifetime = true, // Kiểm tra thời gian sống của token
                    ValidateIssuerSigningKey = true, // Kiểm tra chữ ký của token
                    ValidIssuer = configuration["Jwt:Issuer"], // Issuer mà bạn mong đợi vd: hệ thống 
                    ValidAudience = configuration["Jwt:Audience"], // Audience mà bạn mong đợi vd: client
                    // chữ kí dùng để mã hóa
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])) 
                };
            });

            //đăng kí service
            services.AddScoped<IUserService, UserRepository>();
            services.AddScoped<IGroupService, GroupRepository>();
            services.AddScoped<IAccountService, AccountRepository>();
            services.AddScoped<IFlightService, FlightRepository>();
            services.AddScoped<IFileStorageService, FileStorageRepository>();
            services.AddScoped<IDocumentService, DocumentRepository>();
            services.AddScoped<IDocumentTypeService, DocumentTypeRepository>();
            services.AddScoped<IGroupDocumentService, GroupDocumentRepository>();
            services.AddScoped<IGroupDocumentTypeService, GroupDocumentTypeRepository>();
            services.AddScoped<IJwtTokenService, JwtTokenRepository>();
            return services;
        }
    }
}

