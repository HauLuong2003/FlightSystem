using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.UpdateFlightCommand
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, FlightDTO>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public UpdateFlightCommandHandler(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task<FlightDTO> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }
            var flight = new Flight()
            {
                FlightNo = request.FlightNo,
                Rotue = request.Rotue,
                Departure_Date = request.Departure_Date,
                TimeFlight = request.TimeFlight
            };
            var result = await _flightService.UpdateFlight(request.Id, flight);
            return _mapper.Map<FlightDTO>(result);
        }
    }
}
