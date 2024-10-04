using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.CreateFlightCommand
{
    public class CreateFlightCommandhandler : IRequestHandler<CreateFlightCommand, FlightDTO>
    {
        private readonly IFlightService _flightService;
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public CreateFlightCommandhandler(IFlightService flightService, IMapper mapper, IDocumentService documentService)
        {
            _flightService = flightService;
            _mapper = mapper;
            _documentService = documentService;
        }

        public async Task<FlightDTO> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight()
            {
                FlightNo = request.FlightNo,
                Rotue = request.Rotue,
                TimeFlight = request.TimeFlight,
                Departure_Date = request.Departure_Date
            };

            var result = await _flightService.CreateFilght(flight);

            return _mapper.Map<FlightDTO>(result);
        }
    }
}
