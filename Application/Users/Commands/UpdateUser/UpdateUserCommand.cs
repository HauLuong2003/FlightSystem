﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public Guid GroupId { get; set; }
    }
}
