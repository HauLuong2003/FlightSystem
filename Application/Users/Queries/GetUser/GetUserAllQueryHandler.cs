using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUser
{
    public class GetUserAllQueryHandler : IRequestHandler<GetUserAllQuery, List<UserDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserAllQueryHandler(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // send từ controller tới handle xử lý
        public async Task<List<UserDTO>> Handle(GetUserAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUser();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
