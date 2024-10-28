using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
