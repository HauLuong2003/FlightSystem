using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
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

        public Task<Document> GetDocument()
        {
            throw new NotImplementedException();
        }

        public Task<Document> GetDocumentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Document> UpdateDocument(Guid Id, Document document)
        {
            var documentId = await _dbContext.Documents.FindAsync(Id);
            if (documentId == null)
            {
                throw new ArgumentNullException(nameof(documentId),"document Id is null");
            }
            documentId.Document_Name = document.Document_Name;
            documentId.Note = document.Note;
            documentId.Document_File = document.Document_File;
            documentId.Signature = document.Signature;
            documentId.Update_at = DateTime.Now;
            documentId.Document_Type = document.Document_Type;
            documentId.Flight_No = document.Flight_No;
            await _dbContext.SaveChangesAsync();
            return documentId;
        }
    }
}
