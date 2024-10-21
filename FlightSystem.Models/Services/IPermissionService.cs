using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IPermissionService
    {
        Task<List<Permission>> GetPermission();
        Task<Permission> CreatePermission(Permission permission);
        Task<Permission> UpdatePermission(Guid Id,Permission permission);
        Task<bool> DeletePermission(Guid Id);
    }
}
