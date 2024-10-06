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
        public CreateDocumentTypeCommandHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
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
            return _mapper.Map<DocumentTypeDTO>(result);
        }
    }
}
