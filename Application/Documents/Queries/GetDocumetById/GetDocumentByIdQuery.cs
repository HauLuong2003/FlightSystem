using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumetById
{
    public class GetDocumentByIdQuery : IRequest<DocumentDTO>
    {
        public Guid DocumentId { get; set; }
    }
}
