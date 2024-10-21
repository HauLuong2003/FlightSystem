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

            // Cấu hình xác thực JWT Bearer
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
  
        });

            services.AddAuthorization(options =>
            {
                // Kiễm tra người dùng Role là Admin hoặc permission là Read And Write hoặc only Read
                options.AddPolicy("AdminReadAndWrite", policy =>
                {
                    policy.RequireAssertion(context =>
                    context.User.IsInRole("Admin") ||
                    context.User.HasClaim(c => c.Type == "Permission" &&
                    (c.Value == "Read And Write" || c.Value == "Read Only")));
                });
                // Kiễm tra người dùng  là Admin hoặc permission là Read And Write
                options.AddPolicy("AdminWrite", policy =>
                {
                    policy.RequireAssertion(context =>
                    context.User.IsInRole("Admin") ||
                    context.User.HasClaim(c => c.Type == "Permission" &&
                    (c.Value == "Read And Write" )));
                });
                options.AddPolicy("Verification", policy =>
                {
                    policy.RequireClaim("Permission", "Verification");
                });

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
            services.AddScoped<IPermissionService,PermissionRepository>();
            services.AddScoped<ISettingService,SettingRepository>();
            services.AddScoped<ISendEmailService, SendEmailRepository>();
            services.AddScoped<ICaptchaService, CaptchaRepsitory>();
            return services;
        }
    }
}

