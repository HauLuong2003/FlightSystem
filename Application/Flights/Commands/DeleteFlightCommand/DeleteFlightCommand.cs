using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.DeleteFlightCommand
{
    public class DeleteFlightCommand : IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
    }
}
