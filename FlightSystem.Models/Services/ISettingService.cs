using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface ISettingService
    {
        Task<Setting> GetSetting();
        Task<Setting> updateSetting(Guid Id, Setting setting);
        Task<bool> CheckCaptcha();
    }
}
