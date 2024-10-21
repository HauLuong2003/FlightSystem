using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.CheckCaptcha
{
    public class CheckCaptchaCommand : IRequest<bool>
    {
    }
}
