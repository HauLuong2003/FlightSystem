using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface ISettingService
    {
        Task<Setting> GetSetting(Guid Id);
        Task<Setting> updateSetting(Guid Id, Setting setting);
        Task<Setting> CreateSetting(Setting setting);
    }
}
