using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetPermission
{
    public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, List<PermissionDTO>>
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public GetPermissionQueryHandler(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        public async Task<List<PermissionDTO>> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {

            var permission = await _permissionService.GetPermission();
            return _mapper.Map<List<PermissionDTO>>(permission);
        }
    }
}
