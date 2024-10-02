using Application.Common.Mapping;
using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FilghtDTO : IMapFrom<Flight>
    {
        [Required]
        public Guid Flight_No { get; set; }
        [Required]
        public string Rotue { get; set; } = string.Empty;
        public DateTime Departure_Date { get; set; }
        public TimeSpan TimeFlight { get; set; }
        public int Total_Document { get; set; }
        [Required]
        public string Point_Of_Loadding { get; set; } = string.Empty;
        [Required]
        public string Point_Of_UnLoadding { get; set; } = string.Empty;

    }
}
