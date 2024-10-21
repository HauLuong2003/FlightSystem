using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.GenerateToken
{
    public class GenerateTokenCommand : IRequest<string>
    {
        public User User { get; set; }
    }
}
