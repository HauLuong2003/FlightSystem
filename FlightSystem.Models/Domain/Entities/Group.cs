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
        [StringLength(255)]
        public string Creator { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set;} 
        public ICollection<User>? Users { get; set; }
        [StringLength(150)]
        public string? Members { set; get; }
        [ForeignKey("PermissionId")]
        public Guid PermissionId { get; set; }
        public Permission? Premisstion { get; set; }
        public ICollection<GroupDocument> GroupDocuments { get; set; }
        public ICollection<GroupDocumentType> GroupDocumentTypes { get; set; }

    }
}
