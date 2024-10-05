using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByActive
{
    public class GetUserByActiveHandler : IRequestHandler<GetUserByActive, List<UserDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserByActiveHandler (IUserService userService, IMapper mapper)
        {
            _userService = userService; 
             _mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetUserByActive request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request),"Active is null");
            }
            var user = await _userService.GetUserByActive(request.IsActive);
            return _mapper.Map<List<UserDTO>>(user);    
        }
    }
}
