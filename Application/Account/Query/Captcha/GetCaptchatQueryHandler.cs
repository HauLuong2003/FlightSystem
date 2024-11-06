using Application.Common.InterfaceService;
using Application.Settings.Commands.CheckCaptcha;
using FlightSystem.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.Captcha
{
    public class GetCaptchatQueryHandler : IRequestHandler<GetCaptchaQuery, FileContentResult>
    {
        private readonly ICaptchaService _captchaService;
        private readonly ISessionService _sessionService;
        private readonly IMediator _mediator;
        public GetCaptchatQueryHandler(ICaptchaService captchaService, ISessionService sessionService, IMediator mediator)
        {
            _captchaService = captchaService;
            _sessionService = sessionService;
            _mediator = mediator;
        }

        public async Task<FileContentResult> Handle(GetCaptchaQuery request, CancellationToken cancellationToken)
        {
            // check xem có enabled (true or false)
            var checkCaptcha = await _mediator.Send(new CheckCaptchaCommand());
            // neu true thi thuc hien 
            if (checkCaptcha == true)
            {
                var text = _captchaService.GenerateRandomText();
                var (image, captcha) = _captchaService.GenerateCaptcha(text);
                _sessionService.SetSessionValue("Captcha", captcha);
                // Trả về trực tiếp FileContentResult
                return new FileContentResult(image, "image/png");
            }
            // false thi không có CAPTCHA
            return null!;
        }
    }
}
