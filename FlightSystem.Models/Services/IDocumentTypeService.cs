using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IDocumentTypeService
    {
        Task<List<DocumentType>> GetDocumentType();
        Task<DocumentType> GetDocumentTypeById(Guid Id);
        Task<bool> DeleteDocumentType(Guid Id);
        Task<DocumentType> CreateDocumentType(DocumentType documentType);
        Task<DocumentType> UpdateDocumentType(Guid Id,DocumentType documentType);
    }
}
