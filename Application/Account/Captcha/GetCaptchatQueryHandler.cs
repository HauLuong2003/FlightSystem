using FlightSystem.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Captcha
{
    public class GetCaptchatQueryHandler : IRequestHandler<GetCaptchaQuery, FileContentResult>
    {
        private readonly ICaptchaService _captchaService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISettingService _settingService;
        public GetCaptchatQueryHandler(ICaptchaService captchaService, IHttpContextAccessor contextAccessor, ISettingService settingService)
        {
            _captchaService = captchaService;
            _contextAccessor = contextAccessor;
            _settingService = settingService;
        }

        public   async Task<FileContentResult> Handle(GetCaptchaQuery request, CancellationToken cancellationToken)
        {
            // check xem có enabled (true or false)
            var checkCaptcha = await _settingService.CheckCaptcha();
            // neu true thi thuc hien 
            if (checkCaptcha == true)
            {
                var text = _captchaService.GenerateRandomText();
                var (image, captcha) = _captchaService.GenerateCaptcha(text);
                _contextAccessor.HttpContext.Session.SetString("Captcha", captcha);
                // Trả về trực tiếp FileContentResult
                return new FileContentResult(image, "image/png");
            }
            // false thi không có CAPTCHA
            return null!;
        }
    }
}
