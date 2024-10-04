﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.CreateFlightCommand
{
    public class CreateFlightCommand : IRequest<FlightDTO>
    {
        [Required] 
        public string Rotue { get; set; } = string.Empty;
        [Required]
        public DateTime Departure_Date { get; set; }
        [Required]
        public TimeSpan TimeFlight { get; set; }
    }
}
