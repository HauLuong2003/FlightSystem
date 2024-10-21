using Application.Common.ServiceResponse;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.DeleteFlightCommand
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, ServiceResponse>
    {
        private readonly IFlightService _flightService;
        public DeleteFlightCommandHandler(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<ServiceResponse> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
           if (request == null)
           {
                return new ServiceResponse(false,"Id is null");
           }
           var flight = await _flightService.DeleteFlight(request.Id);
            if(flight == false)
            {
                return new ServiceResponse(flight, "delete don't success");
            }
            return new ServiceResponse(flight, "delete success");
        }
    }
}
