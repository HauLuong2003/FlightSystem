using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface ICaptchaService
    {
        string GenerateRandomText();
        (byte[], string) GenerateCaptcha(string text);
    }
}
