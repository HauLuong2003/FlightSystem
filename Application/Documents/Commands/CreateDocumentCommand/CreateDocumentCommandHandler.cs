using Application.Documents.Commands.CreateGroupDocumentCommand;
using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateDocumentCommand
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocument, DocumentDTO>

    {
        private readonly IDocumentService _documentService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateDocumentCommandHandler(IDocumentService documentService, IMapper mapper, IMediator mediator)
        {
            _documentService = documentService;
            _mapper = mapper;
            _mediator = mediator;

        }
        public async Task<DocumentDTO> Handle(CreateDocument request, CancellationToken cancellationToken)
        {
            var document = new Document()
            {
                Document_Name = request.Document_Name,
                Note = request.Note,   
                Document_File = request.Document_File,
                Creator = request.Creator,
                Signature = request.Signature,
                TypeId = request.TypeId,
                FlightId = request.FlightId,
               
            };
            var result = await _documentService.CreateDocument(document);

            // Thay thế CreateGroupDocumentCommand cho đúng kiểu
            await _mediator.Send(new CreateGroupDocument
            {
                DocumentId = result.DocumentId,
                GroupId = request.GroupId,
            });
            return _mapper.Map<DocumentDTO>(result);
        }
    }
}
