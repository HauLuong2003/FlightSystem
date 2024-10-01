using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Flight_No { get; set; }
        [StringLength(15)]
        public string Rotue { get; set; } = string.Empty;
        public DateTime Departure_Date { get; set; }
        public int Total_Document { get; set; }
        [StringLength(255)]
        public string Point_Of_Loadding { get; set; } = string.Empty;
        [StringLength(255)]
        public string Point_Of_UnLoadding { get; set; } = string.Empty;
        public TimeSpan TimeFlight {get; set; } 

        public ICollection<Document>? Documents { get; set; }
      
    }
}
