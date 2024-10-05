using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateDocumentCommand
{
    public class CreateDocumentCommand : IRequest<DocumentDTO>
    {
        [Required]
        public string Document_Name { get; set; }
      
        public string? Note { get; set; }
        [Required]
        public string Document_File { get; set; }
        public string Signature { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public Guid TypeId { get; set; }
        [Required]
        public Guid FlightId { get; set; }
        
        public Guid GroupId { get; set; }

    }
}
