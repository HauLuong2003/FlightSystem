using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    
    public class DocumentType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid  TypeId { get; set; }
        [StringLength(255)]
        public string Type_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        [StringLength(255)]
        public string Creator { get; set; }
        
        public int? Permission { set; get; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<GroupDocumentType> GroupDocumentTypes { get; set; }
    }
}
