using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.RefreshToken
{
    public class SetRefreshToken : IRequest<Unit>
    {
        public User user {  get; set; }
    }
}
