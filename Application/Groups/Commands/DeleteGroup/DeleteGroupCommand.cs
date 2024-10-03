using Application.Common.ServiceResponse;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommand : IRequest<ServiceResponse>
    {
       public Guid Id { get; set; }
    }
}
