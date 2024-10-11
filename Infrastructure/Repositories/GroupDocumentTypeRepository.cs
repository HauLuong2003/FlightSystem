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
    public class GroupDocumentTypeRepository : IGroupDocumentTypeService
    {
        private readonly FlightSystemDBContext _dbContext;
        public GroupDocumentTypeRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateGroupDocumentType(GroupDocumentType groupDocumentType)
        {
            await _dbContext.GroupDocumentsTypes.AddAsync(groupDocumentType);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGroupDocumentType(GroupDocumentType groupDocumentType)
        {
           var groupDocumentType1 = await _dbContext.GroupDocumentsTypes.FindAsync(groupDocumentType);
            if (groupDocumentType1 == null)
            {
                return false;
            }
             _dbContext.GroupDocumentsTypes.Remove(groupDocumentType1);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateGroupDocumentType(GroupDocumentType groupDocumentType)
        {
            var groupDocumentType1 = await _dbContext.GroupDocumentsTypes.FindAsync(groupDocumentType);
            if(groupDocumentType1 == null)
            {
                return false;
            }
            //groupDocumentType1.TypeId = groupDocumentType.TypeId;
            groupDocumentType1.GroupId = groupDocumentType.GroupId;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckGroupAccessDocument(GroupDocumentType groupDocumentType)
        {
            var groupHasAccess = await _dbContext.GroupDocumentsTypes
                .AnyAsync(gd => gd.TypeId == groupDocumentType.TypeId && gd.GroupId == groupDocumentType.GroupId);

            return groupHasAccess;
        }

    }
}
