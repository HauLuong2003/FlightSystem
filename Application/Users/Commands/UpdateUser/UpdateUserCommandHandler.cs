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

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IUserService _userService; //IUserService để thực hiện việc tạo người dùng
        private readonly IMapper _mapper;// IMapper để ánh xạ từ entity User sang UserDTO.
        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException("user is null");
            var userEntity = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                IsActive = request.IsActive,
                GroupId = request.GroupId
            };
            var result = await _userService.UpdateUser(request.UserId, userEntity);
            return _mapper.Map<UserDTO>(result);
        }
    }
}
