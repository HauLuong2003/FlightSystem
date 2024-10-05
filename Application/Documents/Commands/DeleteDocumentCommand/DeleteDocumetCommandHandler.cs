using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.DeleteDocumentCommand
{
    public class DeleteDocumetCommandHandler : IRequestHandler<DeleteDocumentCommand, ServiceResponse>
    {
        private readonly IDocumentService _documentService;

        public DeleteDocumetCommandHandler(IDocumentService documentService) 
        {
            _documentService = documentService;
        }
        public async Task<ServiceResponse> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            if (request.DocumentId == Guid.Empty)
            {
                return new ServiceResponse(false,"Id is null");
            }

            var documentId = request.DocumentId;
            var result = await _documentService.DeleteDocument(documentId);
            if (result == false)
            {
                return new ServiceResponse(false, "Delete don't document success");
            }

            return new ServiceResponse(true,"Delete document success");
        }
    }
}
