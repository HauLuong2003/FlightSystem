using Application.Account.Command.GenerateToken;
using Application.Account.Command.LoginCommand;
using Application.Account.Command.SendEmail;
using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.ForgetPasswordCommand
{
    public class ForgetPassWordCommandHandler : IRequestHandler<ForgetPassWordCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;
        
        public ForgetPassWordCommandHandler(IAccountService accountService, IMediator mediator)
        {
            _mediator = mediator;
            _accountService = accountService;
            
        }

        public async Task<string> Handle(ForgetPassWordCommand request, CancellationToken cancellationToken)
        {
            if (request.Email == null)
            {
                throw new ArgumentException("Email is null");
            }
            var CheckEmail = await _accountService.FrogetPassword(request.Email);
            if (CheckEmail == false)
            {
                throw new ArgumentException("check email don't success or user don't active");
            }
            var email = await _mediator.Send(new SendEmailCommand
            {
                Email = request.Email,
            });
            if (email == false)
            {
                throw new ArgumentException("send email don't success");
            }
            var jwt = await _mediator.Send(new GenerateTokenVerificationCommand
            {
                Email = request.Email
            });
            return jwt;
        }
    }
}
