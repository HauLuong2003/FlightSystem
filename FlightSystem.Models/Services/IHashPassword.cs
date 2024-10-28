using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IHashPassword
    {
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
    }
}
