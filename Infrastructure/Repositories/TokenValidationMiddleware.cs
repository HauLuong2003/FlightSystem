using FlightSystem.Domain.Services;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TokenValidationMiddleware :IMiddleware
    {
        private readonly ITokenBlacklistService _tokenBlacklistService;
        private readonly string[] _publicRoutes = new[]
       {
            "/api/autho/Login", 
            "/api/Autho/RefreshToken",
            "/api/Autho/ForgetPassword",
            "/api/Autho/Captcha"
        };
        public TokenValidationMiddleware(ITokenBlacklistService tokenBlacklistService)
        {
         
            _tokenBlacklistService = tokenBlacklistService;
        }
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Check if the request path is a public route
            if (_publicRoutes.Contains(context.Request.Path.ToString()))
            {
                await next(context); // Skip token validation and continue
                return;
            }
            // nếu các request khác trên thì kiễm tra token có trong blackList không
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var isTokenBlacklisted = await _tokenBlacklistService.IsTokenBlacklisted(token);
            if (!string.IsNullOrEmpty(token) && isTokenBlacklisted )
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token is blacklisted.");
                return;
            }
            //nếu không trong blackList thì tiếp tục thực hiện
            await next(context);
        }
    }
}
