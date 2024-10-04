using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.UpdateDocumentCommand
{
    public class UpdateDocumentCommand : IRequest<DocumentDTO>
    {
        public Guid DocumentId { get; set; }
        public string Document_Name { get; set; }

        public string? Note { get; set; }

        public string Document_File { get; set; }

        public string? Signature { get; set; }

        public Guid FlightId { get; set; }
        public string Creator { get; set; }
        public Guid TypeId { get; set; }
    }
}
