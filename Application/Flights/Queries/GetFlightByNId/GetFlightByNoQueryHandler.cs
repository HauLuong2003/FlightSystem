using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlightById
{
    public class GetFlightByNoQueryHandler : IRequestHandler<GetFlightByIdQuery, FlightDTO>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public GetFlightByNoQueryHandler(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task<FlightDTO> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(request.Id),"Flight No is null");
            }
            var flight = await _flightService.GetFlightById(request.Id);
            return _mapper.Map<FlightDTO>(flight);
        }
    }
}
