using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.CheckDocumentAccess
{
    public class CheckDocumentAccessQuery : IRequest<bool>
    {
        public Guid DocumentId { get; set; }
        public Guid GroupId{ get; set; }

    }
}
