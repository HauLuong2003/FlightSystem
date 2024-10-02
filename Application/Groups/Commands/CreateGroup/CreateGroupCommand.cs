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
        
        [StringLength(150)]
        public string Group_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        public Guid PermissionId { get; set; }
    }
}
