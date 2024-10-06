using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlightByNo
{
    public class GetFlightByNoQuery : IRequest<FlightDTO>
    {
        public string FlightNo { get; set; } 
    }
}
