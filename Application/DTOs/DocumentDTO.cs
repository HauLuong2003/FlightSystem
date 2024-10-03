using Application.Common.Mapping;
using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DocumentDTO : IMapFrom<Document>
    {
        public Guid DocumentId { get; set; }
        
        public string Document_Name { get; set; }
        public int Version { get; set; }
        
        public string? Note { get; set; }
        
        public string Document_File { get; set; }
        
        public string? Signature { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }
        [StringLength(255)]
        public string Creator { get; set; }
    }
}
