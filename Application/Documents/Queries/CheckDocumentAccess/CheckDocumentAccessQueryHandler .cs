using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.CheckDocumentAccess
{
    public class CheckDocumentAccessQueryHandler : IRequestHandler<CheckDocumentAccessQuery, bool>
    { 
        private readonly IGroupDocumentService _groupDocumentService;

        public CheckDocumentAccessQueryHandler(IGroupDocumentService groupDocumentService)
        {            
                _groupDocumentService = groupDocumentService;
            
        }

        public async Task<bool> Handle(CheckDocumentAccessQuery request, CancellationToken cancellationToken)
        {

            var groupDocumet = new GroupDocument()
            {
                GroupId = request.GroupId,
                DocumentId = request.DocumentId
            };
            // sử dụng service kiễm tra 
            var result = await _groupDocumentService.CheckGroupAccessDocument(groupDocumet);
            return result;
        }
    }
}
