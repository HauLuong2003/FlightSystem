using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Domain.Domain.Entities
{
    public class Setting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SettingId { get; set; }
        [StringLength(50)]
        public string? Theme { get; set; } 
        [StringLength(500)]
        public string? Logo { get; set; } 
        [StringLength(255)]
        public string? Captcha { get; set; } 
       
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
