using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserDTO>
    {
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public GetUserByIdQueryHandler (IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
