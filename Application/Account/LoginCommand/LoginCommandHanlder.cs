using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.LoginCommand
{
    public class LoginCommandHanlder : IRequestHandler<Login, AccountResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _jwtTokenService;
        public LoginCommandHanlder(IAccountService accountService, IJwtTokenService jwtTokenService) 
        {
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<AccountResponse> Handle(Login request, CancellationToken cancellationToken)
        {
            if (request.Password == null || request.Email == null) {
                throw new ArgumentNullException(nameof(request), "Email or password is null");
            }
            // comment này do sử dụng gửi email là gmail.com nên ko sử dụng
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

            var jwt =await _jwtTokenService.GenerateToken(loginUser);
            return new AccountResponse { Token =  jwt };
        }
    }
}
