using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Queries.GetDocumentTypeId
{
    public class GetDocumentTypeIdQuery : IRequest<DocumentTypeDTO>
    {
        public Guid Id { get; set; }
    }
}
