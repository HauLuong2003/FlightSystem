using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllGroup();
        Task<Group> GetGroupById(Guid Id);
        Task<Guid> DeleteGroup(Guid Id);
        Task<Group> UpdateGroup(Guid Id, Group group);
        Task<Group> CreateGroup(Group group);
   
    }
}
