using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, List<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetUserByNameQueryHandler(IMapper mapper, IUserService userService) 
        { 
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<List<UserDTO>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request),"request is null");

            }
            var user =  await _userService.GetUserByName(request.Name);
            return _mapper.Map<List<UserDTO>>(user);    
        }
    }
}
