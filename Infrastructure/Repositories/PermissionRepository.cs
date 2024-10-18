using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionService
    {
        private readonly FlightSystemDBContext _dbContext;
        public PermissionRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Permission> CreatePermission(Permission permission)
        {
             await _dbContext.Permissions.AddAsync(permission);
             await _dbContext.SaveChangesAsync();
             return permission;
        }

        public async Task<bool> DeletePermission(Guid Id)
        {
            var permission = await _dbContext.Permissions.FindAsync(Id);
            if (permission == null) return false;
             _dbContext.Permissions.Remove(permission);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Permission>> GetPermission()
        {
            var permission = await _dbContext.Permissions.ToListAsync();
            if(permission == null) return new List<Permission>();
            return permission;
        }

        public async Task<Permission> UpdatePermission(Guid Id, Permission permission)
        {
            var per = await _dbContext.Permissions.FindAsync(Id);
            if(per == null) return new Permission();
            per.Permission_Name = permission.Permission_Name;
            await _dbContext.SaveChangesAsync();
            return per;
        }
    }
}
