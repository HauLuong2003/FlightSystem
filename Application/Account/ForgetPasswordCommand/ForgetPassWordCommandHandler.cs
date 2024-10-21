using Application.Account.LoginCommand;
using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.ForgetPasswordCommand
{
    public class ForgetPassWordCommandHandler : IRequestHandler<ForgetPassWordCommand, string>
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _jwtTokenService;
        public ForgetPassWordCommandHandler(ISendEmailService sendEmailService, IAccountService accountService, IJwtTokenService jwtTokenService)
        {
            _sendEmailService = sendEmailService;
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(ForgetPassWordCommand request, CancellationToken cancellationToken)
        {
            if(request.Email == null)
            {
                throw new ArgumentException("Email is null");
            }
            var CheckEmail = await _accountService.FrogetPassword(request.Email);
            if(CheckEmail == false)
            {
                throw new ArgumentException("check email don't success or user don't active");
            }
            var email = await _sendEmailService.SendEmail(request.Email);
            if(email == false)
            {
                throw new ArgumentException("send email don't success");
            }
            var jwt = await _jwtTokenService.GenerateTokenVerification(request.Email);
            return jwt;
        }
    }
}
