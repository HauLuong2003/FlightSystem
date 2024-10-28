using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<FlightDTO>
    {
        [Required]
        public Guid Id { get; set; } 
    }
}
