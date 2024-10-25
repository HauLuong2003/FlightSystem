using Application.Common.Mapping;
using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDocumentDTO :IMapFrom<GroupDocument>
    {
        public Guid GroupId { get; set; }
        public GroupDTO? Group { get; set; }  // Navigation property to Group

        public Guid DocumentId { get; set; }
        public DocumentDTO? Document { get; set; }  // Navigation property to Document
    }
}
