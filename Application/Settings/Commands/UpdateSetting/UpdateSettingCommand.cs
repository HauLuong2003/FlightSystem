using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommand:IRequest<SettingDTO>
    {
        public Guid Id { get; set; }
        public string? Theme { get; set; }

        public string? Logo { get; set; }

        public string? Captcha { get; set; }
    }
}
