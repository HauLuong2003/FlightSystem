using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PermissionId { get; set; }
        [StringLength(255)]

        public string Permission_Name { get; set; } = string.Empty;
        public ICollection<Group>? Groups { get; set; }

    }
}
