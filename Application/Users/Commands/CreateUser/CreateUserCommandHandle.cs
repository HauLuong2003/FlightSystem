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

namespace Application.Users.Commands
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandle(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {            
            // Tạo đối tượng người dùng mới từ thông tin yêu cầu

            var userEntity = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                IsActive = request.IsActive
            };
            //gọi đến service để thực hiện 
            var result = await _userService.CreateUser(userEntity);

            return _mapper.Map<UserDTO>(result);
            
        }
    }
}
