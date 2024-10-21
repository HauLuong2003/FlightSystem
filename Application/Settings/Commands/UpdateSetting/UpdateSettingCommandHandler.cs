using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.UpdateSetting
{
    internal class UpdateSettingCommandHandler: IRequestHandler<UpdateSettingCommand, SettingDTO>
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        public UpdateSettingCommandHandler(ISettingService settingService, IMapper mapper)
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        public async Task<SettingDTO> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var setting = new Setting()
            {
                Theme = request.Theme,
                Logo = request.Logo,
                Captcha = request.Captcha,               

            };
            var result = await _settingService.updateSetting(request.Id,setting);
            return _mapper.Map<SettingDTO>(result); 
        }
    }
}
