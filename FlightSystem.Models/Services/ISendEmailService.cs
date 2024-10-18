using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(string email);
        Task<bool> VerificationToken(string Verification);
    }
}
