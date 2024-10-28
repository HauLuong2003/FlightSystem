using Application.Account.Command.GenerateToken;
using Application.Account.Command.RefreshToken;
using Application.Settings.Commands.CheckCaptcha;
using Application.Users.Commands.UpdateUser;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.LoginCommand
{
    public class LoginCommandHanlder : IRequestHandler<Login, string>
    {
        private readonly IAccountService _accountService;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHashPassword _hashPassword;
        public LoginCommandHanlder(IAccountService accountService, IMediator mediator, IHttpContextAccessor httpContextAccessor, IHashPassword hashPassword)
        {
            _accountService = accountService;
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
            _hashPassword = hashPassword;
        }
        public async Task<string> Handle(Login request, CancellationToken cancellationToken)
        {
            if (request.Password == null || request.Email == null)
            {
                throw new ArgumentNullException(nameof(request), "Email or password is null");
            }
            // check captcha co true hay false
            var checkCaptcha = await _mediator.Send(new CheckCaptchaCommand());
            // neu true thi thuc hien
            if (checkCaptcha == true)
            {
                var storedCaptcha = _contextAccessor.HttpContext.Session.GetString("Captcha");
                // nếu captcha null or sai thì in ra lỗi
                if (storedCaptcha == null || request.Captcha != storedCaptcha)
                {
                    throw new ArgumentNullException(nameof(storedCaptcha), "Captcha code is null or false");
                }
                //  do sử dụng gửi email là gmail.com nên ko sử dụng @vietjetair
                //else if (!request.Email.EndsWith("@vietjetair.com", StringComparison.OrdinalIgnoreCase))
                //{
                //    throw new ArgumentException(nameof(request), "Email must have the extension @vietjetair.com");
                //}
                // lấy thông tin user
                var loginUser = await _accountService.Login(request.Email);
                // kiễm tra password nếu sai thì trả về lỗi sai password
                if (!_hashPassword.VerifyPasswordHash(request.Password, loginUser.Password, loginUser.PasswordSalt))
                {
                    return "password is incorrect";
                }
                //nếu đúng thì trả về jwt
                else
                {
                    var jwt = await _mediator.Send(new GenerateTokenCommand
                    {
                        User = loginUser,
                    });
                    await _mediator.Send(new SetRefreshToken { Id = loginUser.UserId });
                    return jwt;
                }
            }
            // neu false thi thuc hien
            else
            {
                var loginUser = await _accountService.Login(request.Email);
                if (!_hashPassword.VerifyPasswordHash(request.Password, loginUser.Password, loginUser.PasswordSalt))
                {
                    return "password is incorrect";
                }
                else
                {

                var jwt = await _mediator.Send(new GenerateTokenCommand
                {
                    User = loginUser,
                });
                    await _mediator.Send(new SetRefreshToken { Id = loginUser.UserId });
                    return jwt;
                }
            }

        }
    }
}
