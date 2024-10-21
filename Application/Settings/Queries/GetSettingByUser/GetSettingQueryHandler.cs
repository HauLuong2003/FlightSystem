using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Queries.GetSettingByUser
{
    public class GetSettingQueryHandler : IRequestHandler<GetSettingQuery, SettingDTO>
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        public GetSettingQueryHandler(ISettingService settingService, IMapper mapper)
        {
            _settingService = settingService;
            _mapper = mapper;
        }
        public async Task<SettingDTO> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
           if (request == null)
           {
                throw new ArgumentNullException(nameof(request));
           }
           var setting = await _settingService.GetSetting();
           return _mapper.Map<SettingDTO>(setting);
        }
    }
}
