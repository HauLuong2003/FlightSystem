using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByRefreshToken
{
    public class GetUserByRefreshTokenQuery : IRequest<User>
    {
        [Required]
        public string RefreshToken { get; set; }=string.Empty;
    }
}
