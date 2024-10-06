using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.DeleteGroupDocument
{
    internal class DeleteGroupDocumentCommandHandler : IRequestHandler<DeleteGroupDocumentCommand, ServiceResponse>
    {
        private readonly IGroupDocumentService _groupDocumentService;
        public DeleteGroupDocumentCommandHandler(IGroupDocumentService groupDocumentService)
        {
            _groupDocumentService = groupDocumentService;
        }

        public async Task<ServiceResponse> Handle(DeleteGroupDocumentCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return new ServiceResponse(false, "Id is null");
            }
            var groupDocument = new GroupDocument()
            {
                DocumentId = request.DocumentId,
                GroupId = request.GroupId,
            };
          var result =  await _groupDocumentService.DeleteGroupDocument(groupDocument);
            if(result == false)
            {
                return new ServiceResponse(result, "GroupDocument Id is null");
            }
            return new ServiceResponse(result, "Delete Success");
        }
    }
}
