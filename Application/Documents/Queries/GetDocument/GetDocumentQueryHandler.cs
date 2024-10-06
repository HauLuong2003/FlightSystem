using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocument
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, List<DocumentDTO>>
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public GetDocumentQueryHandler(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        public async Task<List<DocumentDTO>> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetDocument();
            if (document == null) {
             throw new ArgumentNullException(nameof(document),"document is null");
            }
            return _mapper.Map<List<DocumentDTO>>(document);
        }
    }
}
