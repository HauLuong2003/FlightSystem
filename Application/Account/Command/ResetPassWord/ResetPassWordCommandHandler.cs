using Application.Common.ServiceResponse;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.ResetPassWord
{
    public class ResetPassWordCommandHandler : IRequestHandler<ResetPassWordCommand, ServiceResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IHashPassword _hashPassword;
        public ResetPassWordCommandHandler(IAccountService accountService, IHashPassword hashPassword)
        {
            _accountService = accountService;
            _hashPassword = hashPassword;
        }
        public async Task<ServiceResponse> Handle(ResetPassWordCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "request is null");
            }
            else if (request.Password != request.ComfirmPassword)
            {
                return new ServiceResponse(false, "password don't same ");
            }
            _hashPassword.CreatePasswordHash(request.Password,out string passwordHash,out string passwordSalt);
            var user = new User()
            {
                Email = request.Email,
                Password = passwordHash,
                PasswordSalt = passwordSalt
            };
            var result = await _accountService.ChangePassword(user);
            if (result == false)
            {
                return new ServiceResponse(result, "reset password don't success ");
            }
            return new ServiceResponse(result, "reset password success ");
            
        }
    }
}
