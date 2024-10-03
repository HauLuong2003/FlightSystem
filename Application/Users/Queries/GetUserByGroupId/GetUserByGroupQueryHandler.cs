using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByGroupId
{
    public class GetUserByGroupQueryHandler : IRequestHandler<GetUserByGroupQuery, List<UserDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserByGroupQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetUserByGroupQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByGroupId(request.GroupId);
            return _mapper.Map<List<UserDTO>>(user);
        }
    }
}
