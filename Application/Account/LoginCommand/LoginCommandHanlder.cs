﻿using Application.Common.ServiceResponse;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.LoginCommand
{
    public class LoginCommandHanlder : IRequestHandler<Login, string>
    {
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISettingService _settingService;
        public LoginCommandHanlder(IAccountService accountService, IJwtTokenService jwtTokenService,IHttpContextAccessor httpContextAccessor,ISettingService settingService) 
        {
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
            _contextAccessor = httpContextAccessor;
            _settingService = settingService;
        }
        public async Task<string> Handle(Login request, CancellationToken cancellationToken)
        {
            if (request.Password == null || request.Email == null) {
                throw new ArgumentNullException(nameof(request), "Email or password is null");
            }
            // check captcha co true hay false
            var checkCaptcha = await _settingService.CheckCaptcha();
            // neu true thi thuc hien
            if (checkCaptcha == true)
            {
                var storedCaptcha = _contextAccessor.HttpContext.Session.GetString("Captcha");
                if (storedCaptcha == null || request.Captcha != storedCaptcha)
                {
                    throw new ArgumentNullException(nameof(storedCaptcha), "Captcha code is null or false");
                }
                //  do sử dụng gửi email là gmail.com nên ko sử dụng @vietjetair
                //else if (!request.Email.EndsWith("@vietjetair.com", StringComparison.OrdinalIgnoreCase))
                //{
                //    throw new ArgumentException(nameof(request), "Email must have the extension @vietjetair.com");
                //}
                var login = new User()
                {
                    Email = request.Email,
                    Password = request.Password,
                };
                var loginUser = await _accountService.Login(login);
                var jwt = await _jwtTokenService.GenerateToken(loginUser);
                return jwt;
            }
            // neu false thi thuc hien
            else
            {
                var login = new User()
                {
                    Email = request.Email,
                    Password = request.Password,
                };
                var loginUser = await _accountService.Login(login);
                var jwt = await _jwtTokenService.GenerateToken(loginUser);
                return jwt;
            }
               
        }
    }
}
