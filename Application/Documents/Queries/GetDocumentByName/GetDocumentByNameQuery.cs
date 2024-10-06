using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumentByName
{
    public class GetDocumentByNameQuery :IRequest<List<DocumentDTO>>
    {
        public string Name { get; set; }
    }
}
