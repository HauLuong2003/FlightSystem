using Application.Common.Mapping;
using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DocumentTypeDTO : IMapFrom<DocumentType>
    {
        public Guid TypeId { get; set; }
        
        public string Type_Name { get; set; } = string.Empty;
        
        public string? Note { get; set; }
        
        public string Creator { get; set; } = string.Empty;
        
        public string? Permission { set; get; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }
    }
}
