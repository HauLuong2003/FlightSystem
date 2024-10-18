using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.CreatePermisson
{
    public class CreatePermissionCommand : IRequest<PermissionDTO>
    {

        public string PermissionName { get; set; }
    }
}
