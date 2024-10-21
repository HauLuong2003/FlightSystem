using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailCommand : IRequest<UserDTO>
    {
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
