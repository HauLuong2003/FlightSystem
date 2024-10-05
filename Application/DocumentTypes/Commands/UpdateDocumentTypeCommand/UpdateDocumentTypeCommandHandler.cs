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

namespace Application.DocumentTypes.Commands.UpdateDocumentTypeCommand
{
    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, DocumentTypeDTO>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;
        public UpdateDocumentTypeCommandHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        public async Task<DocumentTypeDTO> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request),"document type is null");
            }
            var documentType = new DocumentType()
            {
                Type_Name = request.Type_Name,
                Note = request.Note,
            };
            var result = await _documentTypeService.UpdateDocumentType(request.TypeId,documentType);
            return _mapper.Map<DocumentTypeDTO>(result);
        }

    }
}
