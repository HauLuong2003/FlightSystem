using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetPermission
{
    public class GetPermissionQuery : IRequest<List<PermissionDTO>>
    {

    }
}
