using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumentByType
{
    public class GetDocumentByTypeHandler : IRequestHandler<GetDocumentByType, List<DocumentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;
        public GetDocumentByTypeHandler(IMapper mapper, IDocumentService documentService)
        {
            _mapper = mapper;
            _documentService = documentService;
        }

        public async Task<List<DocumentDTO>> Handle(GetDocumentByType request, CancellationToken cancellationToken)
        {
           if (request == null)
           {
                throw new ArgumentNullException(nameof(request),"request null");
           }
            var document = await _documentService.GetDocumentByType(request.TypeId);
            return _mapper.Map<List<DocumentDTO>>(document);
        }
    }
}
