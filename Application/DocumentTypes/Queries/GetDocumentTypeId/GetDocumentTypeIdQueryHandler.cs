using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Queries.GetDocumentTypeId
{
    public class GetDocumentTypeIdQueryHandler : IRequestHandler<GetDocumentTypeIdQuery, DocumentTypeDTO>
    {
        public readonly IDocumentTypeService _documentTypeService;
        public readonly IMapper _mapper;
        public GetDocumentTypeIdQueryHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        public async Task<DocumentTypeDTO> Handle(GetDocumentTypeIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty) throw new ArgumentNullException(nameof(request), "id is null");
            var result = await _documentTypeService.GetDocumentTypeById(request.Id);
            return _mapper.Map<DocumentTypeDTO>(result);
        }
    }
}
