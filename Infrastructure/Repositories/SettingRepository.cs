using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SettingRepository : ISettingService
    {
        private readonly FlightSystemDBContext _dbContext;
        public SettingRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Setting> CreateSetting(Setting setting)
        {
            await _dbContext.Settings.AddAsync(setting);
            await _dbContext.SaveChangesAsync();
            return setting;
        }

        public async Task<Setting> GetSetting(Guid Id)
        {
            var setting = await _dbContext.Settings.FirstOrDefaultAsync(s => s.UserId ==Id);
            if (setting == null)
            {
                return null!;
            }
            return setting;
        }

        public async Task<Setting> updateSetting(Guid Id, Setting setting)
        {
            var set = await _dbContext.Settings.FindAsync(Id);
            if (set == null)
            {
                return null!;
            }
            set.Logo = setting.Logo;
            set.Captcha = setting.Captcha;
            set.Theme = setting.Theme;
            await _dbContext.SaveChangesAsync();
            return set;

        }
    }
}
