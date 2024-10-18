using Application.Common.ServiceResponse;
using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.DeletePermisson
{
    public class DeletePermissonHandler : IRequestHandler<DeletePermissonCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;
        public DeletePermissonHandler(IMapper mapper, IPermissionService permissionService)
        {
            _mapper = mapper;
            _permissionService = permissionService;
        }

        public async Task<ServiceResponse> Handle(DeletePermissonCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "request null");
            }
            var permisson = await _permissionService.DeletePermission(request.Id);
            if(permisson == false)
            {
                return new ServiceResponse(permisson,"delete don't success");
            }
            return new ServiceResponse(permisson, "delete success");
        }
    }
}
