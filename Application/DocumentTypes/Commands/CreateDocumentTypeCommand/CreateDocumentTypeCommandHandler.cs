using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.CreateDocumentTypeCommand
{
    //xử lý command CreateDocumentTypeCommand và trả về một DocumentTypeDTO.
    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, DocumentTypeDTO>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;
        private readonly IGroupDocumentTypeService _groupDocumentTypeService;
        public CreateDocumentTypeCommandHandler(IDocumentTypeService documentTypeService, IMapper mapper,IGroupDocumentTypeService groupDocumentTypeService)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
            _groupDocumentTypeService = groupDocumentTypeService;
        }

        public async Task<DocumentTypeDTO> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request),"document type is null");
            }
            var documentType = new DocumentType()
            {
                Type_Name = request.Type_Name,
                Note = request.Note,
                Creator = request.Creator               
            };
            var result = await _documentTypeService.CreateDocumentType(documentType);
            var groupDocumentType = new GroupDocumentType()
            {
                GroupId = request.GroupId,
                TypeId = result.TypeId
            };
             await _groupDocumentTypeService.CreateGroupDocumentType(groupDocumentType);

            return _mapper.Map<DocumentTypeDTO>(result);
        }
    }
}
