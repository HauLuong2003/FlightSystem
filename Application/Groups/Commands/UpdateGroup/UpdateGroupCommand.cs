using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.UpdateGroup
{

    public class UpdateGroupCommand : IRequest<GroupDTO>
    {
        [Required]
        public Guid GroupId { get; set; }
        [StringLength(150)]
        [Required]
        public string Group_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        public Guid PermissionId { get; set; }
    
    }
}
