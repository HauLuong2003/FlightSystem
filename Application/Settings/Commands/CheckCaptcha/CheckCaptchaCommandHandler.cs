using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.CheckCaptcha
{
    public class CheckCaptchaCommandHandler : IRequestHandler<CheckCaptchaCommand, bool>
    {
        private readonly ISettingService _settingService;
        public CheckCaptchaCommandHandler(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<bool> Handle(CheckCaptchaCommand request, CancellationToken cancellationToken)
        {
            var checkcaptcha = await _settingService.CheckCaptcha();
            return checkcaptcha;
        }
    }
}
