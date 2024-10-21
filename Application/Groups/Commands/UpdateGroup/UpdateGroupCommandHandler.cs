using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, GroupDTO>
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IGroupService groupService, IMapper mapper)
        {           
            _groupService = groupService;
            _mapper = mapper;
        }
        public async Task<GroupDTO> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group()
            {
                Group_Name = request.Group_Name,
                Note = request.Note,
                PermissionId = request.PermissionId,
            };
            var result = await _groupService.UpdateGroup(request.GroupId,group);
            return _mapper.Map<GroupDTO>(result);

        }
    }
}
