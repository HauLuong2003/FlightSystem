using Application.Account.Command.GenerateToken;
using Application.Users.Queries.GetUserByEmail;
using Application.Users.Queries.GetUserByRefreshToken;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, string>
    {
        private readonly IAccountService _account;
        private readonly IMediator _mediator;
        public RefreshTokenCommandHandler(IAccountService account, IMediator mediator)
        {
            _account = account;
            _mediator = mediator;
        }
        // refresh token
        public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            //lấy user theo Refreshtoken
             var user = await _mediator.Send(new GetUserByRefreshTokenQuery { RefreshToken = request.RefreshToken });
            if (user.RefreshToken == null)
            {
                throw new ArgumentException("user RefreshToken is null");
            }
            // kiễm tra xem Refresh token có giống nhau không 
           else if(user.RefreshToken.Equals(request.RefreshToken))
           {
                var jwt = await _mediator.Send(new GenerateTokenCommand { User = user});
                await _mediator.Send(new SetRefreshToken { Id = user.UserId });
                return jwt;
           }
            throw new UnauthorizedAccessException("Invalid refresh token.");

        }
    }
}
