using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, GroupDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;
        public CreateGroupCommandHandler(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        public async Task<GroupDTO> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group()
            {
                Group_Name = request.Group_Name,
                Note = request.Note,
                PermissionId = request.PermissionId,
            };
            var result = await _groupService.CreateGroup(group);
            return _mapper.Map<GroupDTO>(result);
        }
    }
}
