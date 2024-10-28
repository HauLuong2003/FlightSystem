using Application.Documents.Commands.UpdateDocumentCommand;
using Application.Users.Queries.GetUserByEmail;
using FlightSystem.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.RefreshToken
{
    public class SetRefreshTokenHandler : IRequestHandler<SetRefreshToken, Unit>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtTokenService _jwtTokenService;      
        private readonly IAccountService _accountService;
        public SetRefreshTokenHandler(IHttpContextAccessor httpContextAccessor, IJwtTokenService jwtTokenService, IAccountService accountService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtTokenService = jwtTokenService;

            _accountService = accountService;
        }
        // gửi refresh token vs các thông tin lên cooki và lưu refresh token vào database
        public async Task<Unit> Handle(SetRefreshToken request, CancellationToken cancellationToken)
        {
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            var cookie = new CookieOptions
            {
                SameSite = SameSiteMode.Strict,
                HttpOnly = true,
                Secure = true, // Chỉ sử dụng khi HTTPS được kích hoạt
                Expires = DateTime.Now.AddDays(2),// Lưu thời gian hết hạn trong cookie
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken, cookie);
            // Lưu thời gian hết hạn vào cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshTokenExpires", DateTime.Now.AddDays(2).ToString("o"), cookie);
        
            await _accountService.UpdateRefreshToken(request.Id, refreshToken);
            return Unit.Value;
        }
    }
}
