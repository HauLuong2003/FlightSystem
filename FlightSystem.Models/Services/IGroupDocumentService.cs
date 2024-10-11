using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IGroupDocumentService
    {
        Task CreateGroupDocument(GroupDocument groupDocument);
        Task UpdateGroupDocument(GroupDocument groupDocument);
        Task<bool> DeleteGroupDocument(GroupDocument groupDocument);
        Task<bool> CheckGroupAccessDocument(GroupDocument groupDocument);
    }
}
