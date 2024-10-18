using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Commands.CreateSetting
{
    public class CreateSettingCommand:IRequest<SettingDTO>
    {
        public string? Theme { get; set; }

        public string? Logo { get; set; }

        public string? Captcha { get; set; }

        public Guid userId { get; set; }
    }
}
