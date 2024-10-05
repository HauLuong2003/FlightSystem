using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Queries.GetDocumentType
{
    public class GetDocumentTypeQueryHandler : IRequestHandler<GetDocumentTypeQuery, DocumentTypeDTO>
    {
        public readonly IDocumentTypeService _documentTypeService;
        public readonly IMapper _mapper;
        public GetDocumentTypeQueryHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        public async Task<DocumentTypeDTO> Handle(GetDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var documentType = await _documentTypeService.GetDocumentType();
            return _mapper.Map<DocumentTypeDTO>(documentType);
        }
    }
}
