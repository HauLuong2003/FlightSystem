using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IDocumentService
    {
        Task<Document> CreateDocument(Document document);
        Task<Document> UpdateDocument(Guid Id,Document document);
        Task<bool> DeleteDocument(Guid Id);
        Task<Document> GetDocument();
        Task<Document> GetDocumentById(Guid id);
    }
}
