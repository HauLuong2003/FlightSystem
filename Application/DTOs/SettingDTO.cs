using Application.Common.Mapping;
using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SettingDTO : IMapFrom<Setting>
    {
        public string? Theme { get; set; }
        
        public string? Logo { get; set; }
        
        public string? Captcha { get; set; }
    }
}
