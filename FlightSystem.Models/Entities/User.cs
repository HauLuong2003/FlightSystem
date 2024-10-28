using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FlightSystem.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string Password { get; set; } = null!;
        [StringLength(500)]
        public string PasswordSalt { get; set; } = null!;
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        [StringLength(6)]
        public string? VerificationCode { get; set; } = null;
        [StringLength(500)]
        public string? RefreshToken {  get; set; }
        public DateTime? Create_at { get; set; }       

        public DateTime? Update_at { get; set; }
        [ForeignKey("GroupId")]
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
