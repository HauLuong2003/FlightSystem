using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.DeleteDocumentTypeCommand
{
    public class DeleteDocumentTypeCommand : IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
    }
}
