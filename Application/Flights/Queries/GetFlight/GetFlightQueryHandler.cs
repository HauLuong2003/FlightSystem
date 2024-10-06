using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlight
{
    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, List<FlightDTO>>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public GetFlightQueryHandler(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task<List<FlightDTO>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _flightService.GetFlight();
            return _mapper.Map<List<FlightDTO>>(flight);
        }
    }
}
