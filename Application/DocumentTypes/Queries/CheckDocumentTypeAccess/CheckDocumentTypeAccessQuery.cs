using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Queries.CheckDocumentTypeAccess
{
    public class CheckDocumentTypeAccessQuery : IRequest<bool>
    {
        public Guid TypeId { get; set; }
        public Guid GroupId { get; set; }
    }
}
