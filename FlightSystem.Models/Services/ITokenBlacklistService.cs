using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface ITokenBlacklistService
    {
        Task BlacklistToken(string token);
        Task<bool> IsTokenBlacklisted(string token);
    }
}
