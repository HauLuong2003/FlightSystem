using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.UpdateActiveAccount
{
    internal class UpdateActiveCommandHandler : IRequestHandler<UpdateActiveCommand, Unit>
    {
        private readonly IAccountService _accountService;
        public UpdateActiveCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Unit> Handle(UpdateActiveCommand request, CancellationToken cancellationToken)
        {
            await _accountService.UpdateActiveAccount(request.Id, request.IsActive);
            return Unit.Value;
        }
    }
}
