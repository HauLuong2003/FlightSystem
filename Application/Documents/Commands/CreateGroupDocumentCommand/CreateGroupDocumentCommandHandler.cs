using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateGroupDocumentCommand
{
    public class CreateGroupDocumentCommandHandler : IRequestHandler<CreateGroupDocumentCommand, ServiceResponse>
    {
        private readonly IGroupDocumentService _groupDocumentService;
        public CreateGroupDocumentCommandHandler(IGroupDocumentService groupDocumentService)
        {
            _groupDocumentService = groupDocumentService;
        }

        public async Task<ServiceResponse> Handle(CreateGroupDocumentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Id is null");
            }
            var groupDocument = new GroupDocument()
            {
                DocumentId = request.DocumentId,
                GroupId = request.GroupId,
            };
            await _groupDocumentService.CreateGroupDocument(groupDocument);
            return new ServiceResponse(true, "create success");
        }
    }
}
