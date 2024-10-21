using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.UpdateFlightCommand
{
    public class UpdateFlightCommand :IRequest<FlightDTO>
    {
        [Required]
        public Guid Id { get; set; }

        public string FlightNo { get; set; } = string.Empty;
        public string Rotue { get; set; } = string.Empty;
        public DateTime Departure_Date { get; set; }
        public TimeSpan TimeFlight { get; set; }
    }
}
