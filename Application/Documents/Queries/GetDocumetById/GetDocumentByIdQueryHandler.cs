using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumetById
{
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, DocumentDTO>
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public GetDocumentByIdQueryHandler(IDocumentService documentService, IMapper mapper) 
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        public async Task<DocumentDTO> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request),"Document Id is null");
            }
            var document = await _documentService.GetDocumentById(request.DocumentId);
            return _mapper.Map<DocumentDTO>(document);
        }
    }
}
