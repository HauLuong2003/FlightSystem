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

namespace Application.Documents.Commands.UpdateDocumentCommand
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, DocumentDTO>
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public UpdateDocumentCommandHandler(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        public async Task<DocumentDTO> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            if(request == null) throw new ArgumentNullException(nameof(request),"document is null");
            var document = new Document()
            {
                Document_Name = request.Document_Name,
                Note = request.Note,
                Document_File = request.Document_File,
                Signature = request.Signature,
                FlightId = request.FlightId,
                TypeId = request.TypeId,
            };
            var result = await _documentService.UpdateDocument(request.DocumentId,document);
            return _mapper.Map<DocumentDTO>(result);
        }
    }
}
