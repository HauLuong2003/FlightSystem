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
    public class PermissionDTO : IMapFrom<Permission>
    {
        public Guid PermissionId { get; set; }        
        public string Permission_Name { get; set; } = string.Empty;
    
    }
}
