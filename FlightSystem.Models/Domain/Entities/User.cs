using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FlightSystem.Domain.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [StringLength(255) ]
        public string? Name { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(255)]
        
        public string Email { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        [StringLength(6)]
        public string? VerificationCode { get; set; } = null;
        public DateTime? Create_at { get; set; }
       
        public DateTime? Update_at { get; set; }

        
        public Setting? Setting { get; set; }
        [ForeignKey("GroupId")]
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
