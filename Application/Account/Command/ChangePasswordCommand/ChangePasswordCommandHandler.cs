using Application.Common.ServiceResponse;
using Application.Users.Queries.GetUserByEmail;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.ChangePasswordCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ServiceResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IMediator _mediator;
        private readonly IHashPassword _hashPassword;
        public ChangePasswordCommandHandler(IAccountService accountService, IMediator mediator, IHashPassword hashPassword)
        {
            _accountService = accountService;
            _mediator = mediator;
            _hashPassword = hashPassword;
        }

        public async Task<ServiceResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "request is null");

            }
            var user = await _mediator.Send(new GetUserByEmailQuery { Email = request.Email });
            //kiễm tra password nhập vào và kiễm tra password mới 
            if (_hashPassword.VerifyPasswordHash(request.Password,user.Password,user.PasswordSalt) == true && request.NewPassword == request.ConfirmPassword)
            {
                // tạo mật khẩu băm vs salt
                _hashPassword.CreatePasswordHash(request.NewPassword, out string passwordHash, out string passwordSalt);                
                var newPass = new User()
                {
                    Email = request.Email,
                    Password = passwordHash,
                    PasswordSalt = passwordSalt
                };
                var result = await _accountService.ChangePassword(newPass);
                if (result == false)
                {
                    return new ServiceResponse(result, "Change password don't success");
                }
                return new ServiceResponse(result, "change password success");
            }
            return new ServiceResponse(false, "Password is don't ");
        }
    }
}
