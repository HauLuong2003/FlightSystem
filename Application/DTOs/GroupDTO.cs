using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDTO
    {
        public Guid GroupId { get; set; }
        [StringLength(150)]
        public string Group_Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Note { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }
    }
}
