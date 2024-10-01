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
    public class DeleteUserCommandHanler :IRequestHandler<DeleteUserCommand,Guid>
    {
        private readonly IUserService _userService;
       // private readonly IMapper _mapper;
        public DeleteUserCommandHanler(IUserService userService)
        {
             _userService = userService;
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
                return await _userService.DeleteUser(request.Id);           
        }
    }
}
