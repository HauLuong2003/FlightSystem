using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandhandler : IRequestHandler<DeleteGroupCommand, Guid>
    {
        private readonly IGroupService _groupService;
        public DeleteGroupCommandhandler(IGroupService groupService) 
        { 
            _groupService = groupService;
        }
        public async Task<Guid> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.DeleteGroup(request.Id);
        }
    }
}
