using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Queries.GetGroup
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, List<GroupDTO>>
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GetGroupQueryHandler(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        public async Task<List<GroupDTO>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupService.GetAllGroup();
            return _mapper.Map<List<GroupDTO>>(groups);
        }
    }
}
