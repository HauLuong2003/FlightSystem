using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
    {
        private readonly IJwtTokenService _jwtTokenService;
        public GenerateTokenCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var jwt = await _jwtTokenService.GenerateToken(request.User);
            return jwt;
        }
    }
}
