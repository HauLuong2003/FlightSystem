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
    public class DocumentTypeRepository : IDocumentTypeService
    {
        public readonly FlightSystemDBContext _dbContext;
        public DocumentTypeRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DocumentType> CreateDocumentType(DocumentType documentType)
        {
            documentType.Create_at = DateTime.Now;
            await _dbContext.DocumentTypes.AddAsync(documentType);
            await _dbContext.SaveChangesAsync();
            return documentType;
        }

        public async Task<bool> DeleteDocumentType(Guid Id)
        {
            var documentType = await _dbContext.DocumentTypes.FindAsync(Id);
            if (documentType == null)
            {
                return false;
            }
             _dbContext.Remove(documentType);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DocumentType>> GetDocumentType()
        {
            return await _dbContext.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType> GetDocumentTypeById(Guid Id)
        {
            var documentType = await _dbContext.DocumentTypes.FindAsync(Id);
            if (documentType == null) 
            {
                throw new ArgumentNullException(nameof(documentType),"document type id is null");
            }
            return documentType;
        }

        public async Task<DocumentType> UpdateDocumentType(Guid Id, DocumentType documentType)
        {
            var type = await _dbContext.DocumentTypes.FindAsync(Id);
            if(type == null)
            {
                throw new ArgumentNullException(nameof(type), "document type id is null");
            }
            type.Type_Name = documentType.Type_Name;
            type.Note = documentType.Note;
            type.Creator = documentType.Creator;
            type.Update_at = documentType.Update_at;
            await _dbContext.SaveChangesAsync();
            return type;
        }
    }
}
