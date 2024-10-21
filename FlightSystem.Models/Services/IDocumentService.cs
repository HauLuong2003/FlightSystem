using FlightSystem.Domain.Entities;
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
        Task<List<Document>> GetDocument();
        Task<Document> GetDocumentById(Guid id);
        Task<List<Document>> GetDocumentByName(string name);
        Task<List<Document>> GetDocumentByType(Guid TypeId);
    }
}
