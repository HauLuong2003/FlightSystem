using Application.Common.ServiceResponse;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.CreateGroupDocumentTypeCommand
{
    public class CreateGroupDocumentTypeCommandHandler : IRequestHandler<CreateGroupDocumentTypeCommand, ServiceResponse>
    {
        private readonly IGroupDocumentTypeService _groupDocumentTypeService;
        public CreateGroupDocumentTypeCommandHandler(IGroupDocumentTypeService groupDocumentTypeService) 
        { 
            _groupDocumentTypeService = groupDocumentTypeService;
        }
        public async Task<ServiceResponse> Handle(CreateGroupDocumentTypeCommand request, CancellationToken cancellationToken)
        {
           if(request == null)
            {
                return new ServiceResponse(false,"request is null");
            }
            var groupdocumenttype = new GroupDocumentType()
            {
                GroupId = request.GroupId,
                TypeId = request.TypeId,
            };
            var groupDocumentType = await _groupDocumentTypeService.CreateGroupDocumentType(groupdocumenttype);
            if(groupDocumentType == false)
            {
                return new ServiceResponse(groupDocumentType, "Create don't success");
            }
            return new ServiceResponse(groupDocumentType, "create success");
        }
    }
}
