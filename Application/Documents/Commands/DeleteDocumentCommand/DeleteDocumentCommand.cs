using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.DeleteDocumentCommand
{
    public class DeleteDocumentCommand : IRequest<ServiceResponse>
    {
        public Guid DocumentId { get; set; }
    }
}
