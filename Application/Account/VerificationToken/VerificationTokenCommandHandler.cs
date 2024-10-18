using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.VerificationToken
{
    public class VerificationTokenCommandHandler : IRequestHandler<VerificationTokenCommand, ServiceResponse>
    {
        private readonly ISendEmailService _sendEmailService;

        public VerificationTokenCommandHandler(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public async Task<ServiceResponse> Handle(VerificationTokenCommand request, CancellationToken cancellationToken)
        {
            var Verification = await _sendEmailService.VerificationToken(request.Token);
            if(Verification == false)
            {
                return new ServiceResponse(Verification, "Token don't success");
            }
            return new ServiceResponse(Verification, "Verfication success");
        }
    }
}
