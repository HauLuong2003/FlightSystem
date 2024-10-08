using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.ChangePasswordCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,ServiceResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public ChangePasswordCommandHandler(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        public async Task<ServiceResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return new ServiceResponse(false, "request is null");

            }
            var user = await _userService.GetUserByEmail(request.Email);
            //kiễm tra password nhập vào và kiễm tra password mới 
            if(user.Password ==  request.Password && request.newPassword == request.ConfirmPassword)
            {
                if (user.IsActive == false)
                {
                    return new ServiceResponse(false, "account don't active");
                }
                var newPass = new User()
                {
                    Email = request.Email,
                    Password = request.newPassword
                };               
                var result = await _accountService.ChangePassword(newPass);
                if(result == false)
                {
                    return new ServiceResponse(result, "Change password don't success");
                }
                return new ServiceResponse(result, "change password success");
            }
            return new ServiceResponse(false, "Password is don't or new Password is don't");
        }
    }
}
