using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GroupDocumentRepository : IGroupDocumentService
    {
        private readonly FlightSystemDBContext _dbContext;
        public GroupDocumentRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateGroupDocument(GroupDocument groupDocument)
        {
            await _dbContext.GroupDocuments.AddAsync(groupDocument);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<bool> DeleteGroupDocument(GroupDocument groupDocument)
        {
            var documentGroup = await _dbContext.GroupDocuments.FindAsync(groupDocument);
            if(documentGroup == null )
            {
                return false;
            }
            else if( documentGroup.GroupId != groupDocument.GroupId )
            {
                return false;
            }
             _dbContext.Remove(documentGroup);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateGroupDocument(GroupDocument groupDocument)
        {
             var document = await _dbContext.GroupDocuments.FindAsync(groupDocument.DocumentId);
            if(document == null)
            {
                throw new ArgumentNullException(nameof(groupDocument), "groupDocument is null");
            } 
            document.GroupId = groupDocument.GroupId;
            await _dbContext.SaveChangesAsync();
           
        }


        public async Task<bool> CheckGroupAccessDocument(GroupDocument groupDocument)
        {
            // Kiễm tra có được cấp quyền truy cập  
            var groupHasAccess = await _dbContext.GroupDocuments
                .AnyAsync(gd => gd.DocumentId == groupDocument.DocumentId && gd.GroupId == groupDocument.GroupId);
            // trả về true or false
            return groupHasAccess;
        }
    }
}
