using Application.Common.Mapping;
using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDocumentTypeDTO:IMapFrom<GroupDocumentType>
    {
        public Guid GroupId { get; set; }
        public GroupDTO Group { get; set; }
        public Guid TypeId { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
    }
}
