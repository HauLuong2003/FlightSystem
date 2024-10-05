using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.DeleteDocumentTypeCommand
{
    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand, ServiceResponse>
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DeleteDocumentTypeCommandHandler(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        public async Task<ServiceResponse> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                return new ServiceResponse(false,"Id is null");
            }
            var documentType = await _documentTypeService.DeleteDocumentType(request.Id);
            if(documentType == false)
            {
                return new ServiceResponse(false, "delete documentType don't success");
            }
            return new ServiceResponse(true, "delete documentType success");
        }
    }
}
