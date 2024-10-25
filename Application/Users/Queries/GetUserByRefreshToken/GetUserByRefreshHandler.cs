using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByRefreshToken
{
    public class GetUserByRefreshHandler : IRequestHandler<GetUserByRefreshTokenQuery, User>
    {
        private readonly IAccountService _accountService;
        public GetUserByRefreshHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<User> Handle(GetUserByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserRefreshToken(request.RefreshToken);
            return user;
        }
    }
}
