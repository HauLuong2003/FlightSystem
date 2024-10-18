using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.CreateSetting
{
    public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, SettingDTO>
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        public CreateSettingCommandHandler(ISettingService settingService, IMapper mapper)
        {
            _settingService = settingService;
            _mapper = mapper;
        }
        public async Task<SettingDTO> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var setting = new Setting()
            {
                Theme = request.Theme,
                Logo = request.Logo,
                Captcha = request.Captcha,
                UserId = request.userId
            };
            var result = await _settingService.CreateSetting( setting);
            return _mapper.Map<SettingDTO>(result);
        }
    }
}
