using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DocumentId { get; set; }

        [StringLength(255)]
        public string Document_Name { get; set; }

        public int Version { get; set; }

        [StringLength(255)]
        public string? Note { get; set; }

        public string Document_File { get; set; }

        [StringLength(255)]
        public string? Signature { get; set; }

        public DateTime? Create_at { get; set; }

        public DateTime? Update_at { get; set; }

        [StringLength(255)]
        public string Creator { get; set; }

        // Foreign Key to Flight
        public Guid FlightId { get; set; }  // Ensure it maps to Flight_No in Flight class
        public Flight Flight { get; set; }

        // Foreign Key to Document_Type
        public Guid TypeId { get; set; }
       // public Document_Type DocumentType { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }

}
