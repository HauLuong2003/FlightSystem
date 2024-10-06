using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.UpdateGroupDocumentCommand
{
    internal class UpdateGroupDocumentCommandHandler : IRequestHandler<UpdateGroupDocumentCommand, ServiceResponse>
    {
        private readonly IGroupDocumentService _groupDocumentService;
        public UpdateGroupDocumentCommandHandler(IGroupDocumentService groupDocumentService)
        {
            _groupDocumentService = groupDocumentService;
        }

        public async Task<ServiceResponse> Handle(UpdateGroupDocumentCommand request, CancellationToken cancellationToken)
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
            await _groupDocumentService.UpdateGroupDocument(groupDocument);
            return new ServiceResponse(true, "update success");
        }
    }
}
