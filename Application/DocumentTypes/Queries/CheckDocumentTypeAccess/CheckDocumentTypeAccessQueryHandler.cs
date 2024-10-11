using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Queries.CheckDocumentTypeAccess
{
    public class CheckDocumentTypeAccessQueryHandler : IRequestHandler<CheckDocumentTypeAccessQuery, bool>
    {
        private readonly IGroupDocumentTypeService _groupDocumentTypeService;
        public CheckDocumentTypeAccessQueryHandler(IGroupDocumentTypeService groupDocumentTypeService)
        {
            _groupDocumentTypeService = groupDocumentTypeService;
        }

        public async Task<bool> Handle(CheckDocumentTypeAccessQuery request, CancellationToken cancellationToken)
        {
            var groupDocumentType = new GroupDocumentType()
            {
                TypeId = request.TypeId,
                GroupId = request.GroupId
            };
            var result = await _groupDocumentTypeService.CheckGroupAccessDocument(groupDocumentType);
            return result;
        }
    }
}
