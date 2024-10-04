using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocument
{
    public class GetDocumentQuery : IRequest<List<DocumentDTO>>
    {
    }
}
