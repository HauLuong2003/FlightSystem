using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(User user);
        Task<string> GenerateTokenVerification(string Email);
        string GenerateRefreshToken();
    }
}
