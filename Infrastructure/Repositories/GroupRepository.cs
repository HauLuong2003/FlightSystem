using Application.DTOs;
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
    public class GroupRepository : IGroupService
    {
        private readonly FlightSystemDBContext _dBContext;
        public GroupRepository(FlightSystemDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task<Group> CreateGroup(Group group)
        {
            group.Create_at = DateTime.Now;
            await _dBContext.AddAsync(group);
            await _dBContext.SaveChangesAsync();
            return group;
        }

        public async Task<Guid> DeleteGroup(Guid Id)
        {
            var groupId = await _dBContext.Groups.FindAsync(Id);
            if (groupId == null)
            {
                throw new NotImplementedException("Group is null");
            }
             _dBContext.Groups.Remove(groupId);
            await _dBContext.SaveChangesAsync();
            return Id;
        }

        public async Task<List<Group>> GetAllGroup()
        {
            return await _dBContext.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupById(Guid Id)
        {
            var groupId = await _dBContext.Groups.FindAsync(Id);
            if (groupId == null)
            {
                throw new NotImplementedException("Group is null");
            }
            return groupId;
        }

        public async Task<Group> UpdateGroup(Guid Id, Group group)
        {
            var groupId = await _dBContext.Groups.FindAsync(Id);
            if (groupId == null)
            {
                throw new NotImplementedException("Group is null");
            }
            groupId.Group_Name = group.Group_Name;
            groupId.Note = group.Note;
            groupId.Update_at = DateTime.Now;          
            await _dBContext.SaveChangesAsync();
            return groupId;
        }
    }
}
