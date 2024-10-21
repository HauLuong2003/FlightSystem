using Application.Common.Mapping;
using FlightSystem.Domain.Entities;
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
        public Guid Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        
        public string Logo { get; set; } = string.Empty ;
        
        public bool Captcha { get; set; } 
    }
}
