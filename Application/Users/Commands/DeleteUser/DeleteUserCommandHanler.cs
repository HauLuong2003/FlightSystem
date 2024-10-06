using Application.Common.ServiceResponse;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHanler : IRequestHandler<DeleteUserCommand, ServiceResponse>
    {
        private readonly IUserService _userService;
        // private readonly IMapper _mapper;
        public DeleteUserCommandHanler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ServiceResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty) return new ServiceResponse(false,"userId is null");
            var deleteId = await _userService.DeleteUser(request.Id);
            if (deleteId == false)
            {
                return new ServiceResponse(deleteId, "Delete don't successfully");
            }
            return new ServiceResponse(deleteId, "Delete successfully");
        }
    }
}
