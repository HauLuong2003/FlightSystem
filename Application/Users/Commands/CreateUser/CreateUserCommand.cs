using Application.DTOs;
using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        //Command này triển khai từ IRequest<UserDTO>, nó sẽ trả về một UserDTO khi hoàn tất.
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public Guid GroupId { get; set; }

    }
}
