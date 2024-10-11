using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IGroupDocumentTypeService
    {
        Task<bool> CreateGroupDocumentType(GroupDocumentType groupDocumentType);
        Task<bool> DeleteGroupDocumentType(GroupDocumentType groupDocumentType);
        Task<bool> UpdateGroupDocumentType(GroupDocumentType groupDocumentType);
        Task<bool> CheckGroupAccessDocument(GroupDocumentType groupDocumentType);
    }
}
