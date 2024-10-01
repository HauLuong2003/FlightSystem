using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    
    public class Document_Type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid  TypeId { get; set; }
        [StringLength(255)]
        public string Type_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }

        public ICollection<Document>? Documents { get; set; }
    }
}
