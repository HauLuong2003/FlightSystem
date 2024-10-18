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
    public class FlightDTO : IMapFrom<Flight>
    {
        
        public Guid FlightId { get; set; }    
        public string FlightNo { get; set; }
        public string Rotue { get; set; } = string.Empty;
        public DateTime Departure_Date { get; set; }
        public TimeSpan TimeFlight { get; set; }
        public int Total_Document { get; set; }
        public ICollection<DocumentDTO>? Documents { get; set; }
      
    }
}
