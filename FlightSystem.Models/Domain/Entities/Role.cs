using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid RoleId { get; set; }
        [StringLength(150)]
        public string Role_Name { get; set; } 
        public ICollection<User> Users { get; set; }
    }
}
