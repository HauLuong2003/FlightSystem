using Application.Account.Command.UpdateActiveAccount;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByEmail;
using Application.Users.Queries.GetUserById;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly ITokenBlacklistService _tokenBlacklistService;
        private readonly IMediator _mediator;
        public LogoutCommandHandler(ITokenBlacklistService tokenBlacklistService,IMediator mediator)
        {
            _tokenBlacklistService = tokenBlacklistService;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            // neu Id rong thi dua vao blacklist
            if (request.Id == Guid.Empty)
            {
                await _tokenBlacklistService.BlacklistToken(request.Token);
                return Unit.Value;
            }
            //neu Id co thi goi den User va update IsActive
            else
            {
                await _tokenBlacklistService.BlacklistToken(request.Token);
                var user = await _mediator.Send(new GetUserByIdQuery { Id = request.Id });

                user.IsActive = false;
                await _mediator.Send(new UpdateActiveCommand { Id = user.UserId, IsActive = user.IsActive });
                return Unit.Value;
            }
        }
    }
}
