using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByGroupId
{
    public class GetUserByGroupQuery : IRequest<List<UserDTO>>
    {
        public Guid GroupId { get; set; }
    }
}
