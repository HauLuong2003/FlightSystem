using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUser
{
    public class GetUserAllQuery : IRequest<List<UserDTO>>
    {

    }
}
