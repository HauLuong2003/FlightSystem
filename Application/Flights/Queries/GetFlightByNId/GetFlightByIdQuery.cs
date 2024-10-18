using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<FlightDTO>
    {
        public Guid Id { get; set; } 
    }
}
