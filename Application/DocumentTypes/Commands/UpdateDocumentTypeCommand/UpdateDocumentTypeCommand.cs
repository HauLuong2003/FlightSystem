using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.UpdateDocumentTypeCommand
{
    public class UpdateDocumentTypeCommand : IRequest<DocumentTypeDTO>
    {
        [Required]
        public Guid TypeId { get; set; }

        public string Type_Name { get; set; } = string.Empty;

        public string? Note { get; set; }

    }
}
