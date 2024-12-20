﻿using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.CreatePermisson
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, PermissionDTO>
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public CreatePermissionCommandHandler(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }
        public async Task<PermissionDTO> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var permission = new Permission()
            {
                Permission_Name = request.PermissionName
            };
            var result = await _permissionService.CreatePermission(permission);
            return _mapper.Map<PermissionDTO>(result);
        }

    }
}
