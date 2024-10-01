using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GroupId { get; set; }
        [StringLength(150)]
        public string Group_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set;} 
        public ICollection<User>? Users { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
    }
}
