using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<PermissionDTO>
    {
        public Guid Id { get; set; }
        [Required]
        public string PermissionName {  get; set; }
    }
}
