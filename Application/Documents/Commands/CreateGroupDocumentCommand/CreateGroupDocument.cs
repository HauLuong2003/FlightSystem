using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateGroupDocumentCommand
{
    public class CreateGroupDocument : IRequest<ServiceResponse>
    {
        [Required]
        public Guid DocumentId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
    }
}
