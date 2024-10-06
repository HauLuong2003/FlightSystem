using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumentByName
{
    public class GetDocumentByNameQueryHandler : IRequestHandler<GetDocumentByNameQuery, List<DocumentDTO>>
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public GetDocumentByNameQueryHandler(IDocumentService documentService, IMapper mapper) 
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        public async Task<List<DocumentDTO>> Handle(GetDocumentByNameQuery request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request),"name is null");
            }
            var document = await _documentService.GetDocumentByName(request.Name);
            return _mapper.Map<List<DocumentDTO>>(document);
        }
    }
}
