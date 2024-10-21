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

namespace Application.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailCommandHandler : IRequestHandler<GetUserByEmailCommand, UserDTO>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserByEmailCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        public async Task<UserDTO> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
        {
           var userEmail = await _userService.GetUserByEmail(request.Email);
            return _mapper.Map<UserDTO>(userEmail);
        }
    }
}
