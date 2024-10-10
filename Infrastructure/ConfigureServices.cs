﻿using FlightSystem.Domain.Services;
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
            //// Xử lý  "Bearer " trong token
            //options.Events = new JwtBearerEvents
            //{
            //    OnMessageReceived = context =>
            //    {
            //        var token = context.Request.Headers["Authorization"].FirstOrDefault();
            //        if (token != null && token.StartsWith("Bearer "))
            //        {
            //            context.Token = token.Substring(7); // Bỏ tiền tố "Bearer "
            //        }
            //        return Task.CompletedTask;
            //    }
            //};
        });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ReadAndWritePolicy", policy =>
            //        policy.RequireClaim("permission", "Read And Write"));

            //    //options.AddPolicy("CanEditUsersPolicy", policy =>
            //    //policy.RequireClaim("Permission", "CanEditUsers"));
            //});

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

