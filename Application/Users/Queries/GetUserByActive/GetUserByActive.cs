using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByActive
{
    public class GetUserByActive : IRequest<List<UserDTO>>
    {
        public bool IsActive { get; set; }
    }
}
