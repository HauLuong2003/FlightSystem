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

namespace Application.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, GroupDTO>
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GetGroupByIdQueryHandler(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        public async Task<GroupDTO> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var group = await _groupService.GetGroupById(request.GroupId);
            return _mapper.Map<GroupDTO>(group);
        }
    }
}
