using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumentByName
{
    public class GetDocumentByNameQuery :IRequest<List<DocumentDTO>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
