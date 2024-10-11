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
    public class DocumentRepository : IDocumentService
    {
        private FlightSystemDBContext _dbContext;
        public DocumentRepository(FlightSystemDBContext dBContext) 
        {
            _dbContext = dBContext;
        }
        public async Task<Document> CreateDocument(Document document)
        {
            document.Version = 1;
            document.Create_at = DateTime.Now;
            document.Update_at = DateTime.Now;
            await _dbContext.AddAsync(document);
            await _dbContext.SaveChangesAsync();
            return document;
        }

        public async Task<bool> DeleteDocument(Guid Id)
        {
           var documentId = await _dbContext.Documents.FindAsync(Id);
            if (documentId == null) {
                return false;
            }
             _dbContext.Documents.Remove(documentId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Document>> GetDocument()
        {
           var document = await _dbContext.Documents.ToListAsync();
            if(document == null)
            {
                return null!;
            }
            return document;
        }

        public async Task<Document> GetDocumentById(Guid id)
        {
            var document = await _dbContext.Documents.Include(d => d.GroupDocuments)                                                       
                                                      .ThenInclude(gd => gd.Group)
                                                      .FirstOrDefaultAsync(d => d.DocumentId == id);
            if (document == null) 
            { 
               throw new ArgumentNullException(nameof(document),"document is null");
            }
            return document;
        }

        public async Task<List<Document>> GetDocumentByName(string name)
        {
            var document = await _dbContext.Documents.Where(doc => doc.Document_Name.Contains(name)).ToListAsync();
            if (document == null) 
            {
                throw new ArgumentNullException(nameof(document), "document is null");
            }
            return document;
        }

        public async Task<Document> UpdateDocument(Guid Id, Document document)
        {
            var documentId = await _dbContext.Documents.FindAsync(Id);
            if (documentId == null)
            {
                throw new ArgumentNullException(nameof(documentId),"document Id is null");
            }
            documentId.Document_Name = document.Document_Name;
            documentId.Version = document.Version + 0.1;
            documentId.Note = document.Note;
            documentId.Document_File = document.Document_File;
            documentId.Signature = document.Signature;
            documentId.Update_at = DateTime.Now;
            documentId.TypeId = document.TypeId;
            documentId.FlightId = document.FlightId;
            await _dbContext.SaveChangesAsync();
            return documentId;
        }
    }
}
