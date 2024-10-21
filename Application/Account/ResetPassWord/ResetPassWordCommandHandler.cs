using Application.Common.ServiceResponse;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.ResetPassWord
{
    public class ResetPassWordCommandHandler : IRequestHandler<ResetPassWordCommand, ServiceResponse>
    {
        private readonly IAccountService _accountService;
       
        public ResetPassWordCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
           
        }
        public async Task<ServiceResponse> Handle(ResetPassWordCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
               return new ServiceResponse(false,"request is null");
            }
            else if(request.Password != request.ComfirmPassword)
            {
                return new ServiceResponse(false, "password don't same ");
            }
            var user = new User()
            {
                Email = request.Email,
                Password = request.Password,
            };
             var result =  await _accountService.ChangePassword(user);
            if(result == false)
            {
                return new ServiceResponse(result, "reset password don't success ");
            }
            return new ServiceResponse(result, "reset password success ");

        }
    }
}
