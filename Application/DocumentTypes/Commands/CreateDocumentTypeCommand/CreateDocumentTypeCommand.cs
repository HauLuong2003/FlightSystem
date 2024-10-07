using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.CreateDocumentTypeCommand
{
    //Command này triển khai từ IRequest<DocumentTypeDTO>, nó sẽ trả về một DocumentTypeDTO khi hoàn tất.

    public class CreateDocumentTypeCommand : IRequest<DocumentTypeDTO>
    {       
        [Required]
        public string Type_Name { get; set; } = string.Empty;
        [Required]
        public string? Note { get; set; }
        [Required]
        public string Creator { get; set; }
        public Guid GroupId { get; set; }
    }
}
