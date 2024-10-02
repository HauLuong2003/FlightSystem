using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQuery : IRequest<GroupDTO>
    {
        public Guid GroupId { get; set; }
    }
}
