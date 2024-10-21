using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.GenerateToken
{
    public class GenerateTokenVerificationCommandHandler : IRequestHandler<GenerateTokenVerificationCommand, string>
    {
        private readonly IJwtTokenService _jwtTokenService;
        public GenerateTokenVerificationCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(GenerateTokenVerificationCommand request, CancellationToken cancellationToken)
        {
            var jwt = await _jwtTokenService.GenerateTokenVerification(request.Email);
            return jwt;
        }
    }
}
