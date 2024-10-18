using Application.Common.ServiceResponse;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.DeletePermisson
{
    public class DeletePermissonCommand : IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
    }
}
