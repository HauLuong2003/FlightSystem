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

namespace Application.Documents.Commands.CreateDocumentCommand
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, DocumentDTO>

    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public CreateDocumentCommandHandler(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        public async Task<DocumentDTO> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = new Document()
            {
                Document_Name = request.Document_Name,
                Note = request.Note,               
                Creator = request.Creator,
                Signature = request.Signature,
                TypeId = request.TypeId,
                FlightId = request.FlightId,
                GroupId = request.GroupId,
            };
            var result = await _documentService.CreateDocument(document);
            return _mapper.Map<DocumentDTO>(result);
        }
    }
}
