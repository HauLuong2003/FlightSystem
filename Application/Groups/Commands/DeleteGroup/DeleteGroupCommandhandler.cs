using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandhandler : IRequestHandler<DeleteGroupCommand, ServiceResponse>
    {
        private readonly IGroupService _groupService;
        public DeleteGroupCommandhandler(IGroupService groupService) 
        { 
            _groupService = groupService;
        }
        public async Task<ServiceResponse> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty) return new ServiceResponse(false, "userId is null");
            var deleteId = await _groupService.DeleteGroup(request.Id);
            if(deleteId != request.Id)
            {
                return new ServiceResponse(false, "Delete don't successfully");
            }
            return new ServiceResponse(true, "Delete successfully");
        }
    }
}
