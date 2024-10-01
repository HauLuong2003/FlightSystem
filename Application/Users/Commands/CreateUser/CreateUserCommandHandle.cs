﻿using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    //xử lý command CreateUserCommand và trả về một UserDTO.
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUserService _userService; //IUserService để thực hiện việc tạo người dùng
        private readonly IMapper _mapper;// IMapper để ánh xạ từ entity User sang UserDTO.

        public CreateUserCommandHandle(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Tạo đối tượng người dùng mới từ thông tin yêu cầu

            var userEntity = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                IsActive = request.IsActive,
                GroupId = request.GroupId
            };
            //gọi đến service để thực hiện 
            var result = await _userService.CreateUser(userEntity);
            //sau khi thực hiện thêm thành công thì ánh xạ cho UserDTO
            return _mapper.Map<UserDTO>(result);

        }
    }
}