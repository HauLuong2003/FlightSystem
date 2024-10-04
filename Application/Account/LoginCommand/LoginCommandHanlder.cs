using Application.Common.ServiceResponse;
using Application.DTOs;
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
    public class LoginCommandHanlder : IRequestHandler<Login, ServiceResponse>
    {
        private readonly IAccountService _accountService;
        public LoginCommandHanlder(IAccountService accountService) 
        {
            _accountService = accountService;
        }
        public async Task<ServiceResponse> Handle(Login request, CancellationToken cancellationToken)
        {
            var login = new User()
            {
                Email = request.Email,
                Password = request.Password,
            };
            var loginUser = await _accountService.Login(login);
            if (loginUser == false)
            {
                return new ServiceResponse(loginUser, "login don't successfully");
            }
            return new ServiceResponse(loginUser, "login sucessfully");
        }
    }
}
