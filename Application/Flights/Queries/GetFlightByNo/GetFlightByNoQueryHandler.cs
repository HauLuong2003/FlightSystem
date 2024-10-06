using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Queries.GetFlightByNo
{
    public class GetFlightByNoQueryHandler : IRequestHandler<GetFlightByNoQuery, FlightDTO>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public GetFlightByNoQueryHandler(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task<FlightDTO> Handle(GetFlightByNoQuery request, CancellationToken cancellationToken)
        {
            if(request.FlightNo == null)
            {
                throw new ArgumentNullException(nameof(request.FlightNo),"Flight No is null");
            }
            var flight = await _flightService.GetFlightByNo(request.FlightNo);
            return _mapper.Map<FlightDTO>(flight);
        }
    }
}
