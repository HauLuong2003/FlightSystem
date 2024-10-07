using Application.Common.ServiceResponse;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.DeleteGroupDocumentType
{
    public class DeleteGroupDocumentTypeCommandHandler : IRequestHandler<DeleteGroupDocumentTypeCommand,ServiceResponse>
    {
        private readonly IGroupDocumentTypeService _groupDocumentTypeService;
        public DeleteGroupDocumentTypeCommandHandler(IGroupDocumentTypeService groupDocumentTypeService)
        {
            _groupDocumentTypeService = groupDocumentTypeService;
        }

        public async Task<ServiceResponse> Handle(DeleteGroupDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "request is null");
            }
            var groupdocumenttype = new GroupDocumentType()
            {
                GroupId = request.GroupId,
                TypeId = request.TypeId,
            };
            var groupDocumentType = await _groupDocumentTypeService.DeleteGroupDocumentType(groupdocumenttype);
            if (groupDocumentType == false)
            {
                return new ServiceResponse(groupDocumentType, "Delete don't success");
            }
            return new ServiceResponse(groupDocumentType, "Delete success");
        }
    }
}
