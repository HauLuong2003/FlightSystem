using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<GroupDTO>
    {       
        public string Group_Name { get; set; } = string.Empty;
      
        public string Creator { get; set; }
        public string? Note { get; set; }
        public Guid PermissionId { get; set; }
    }
}
