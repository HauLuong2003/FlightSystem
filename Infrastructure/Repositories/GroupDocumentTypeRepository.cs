using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            var GroupDocumentType = await _dbContext.DocumentTypes
                   .FirstOrDefaultAsync(gd => gd.TypeId == groupDocumentType.TypeId);
            if (GroupDocumentType != null)
            {
                if (GroupDocumentType!.Permission != 0)
                {
                    GroupDocumentType!.Permission += 1;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    GroupDocumentType!.Permission = 1;
                    await _dbContext.SaveChangesAsync();
                }                          
            }
            else
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteGroupDocumentType(GroupDocumentType groupDocumentType)
        {
           var groupDocumentType1 = await _dbContext.GroupDocumentsTypes.FindAsync(groupDocumentType);
            if (groupDocumentType1 == null)
            {
                return false;
            }
            // truy vấn và kiễm tra xem số group được truy cập 
            var GroupPermisson = await _dbContext.DocumentTypes
                  .FirstOrDefaultAsync(gd => gd.TypeId == groupDocumentType.TypeId);
            // lấy số hiện tại -1 
            if (GroupPermisson != null)
            {
                if (GroupPermisson.Permission != 0)
                {
                    GroupPermisson.Permission  -= 1;
                    await _dbContext.SaveChangesAsync();
                }
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
            //kiễm tra xem groupId và DocumentType Id có mối quan hệ không
            var groupHasAccess = await _dbContext.GroupDocumentsTypes
                        .AnyAsync(gd => gd.GroupId == groupDocumentType.GroupId && gd.TypeId == groupDocumentType.TypeId);
            // trả về true false
            return groupHasAccess;
        }

    }
}
