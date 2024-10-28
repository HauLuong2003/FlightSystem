using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.GenerateToken
{
    public class GenerateTokenCommand : IRequest<string>
    {
        [Required]
        public User User { get; set; }
    }
}
