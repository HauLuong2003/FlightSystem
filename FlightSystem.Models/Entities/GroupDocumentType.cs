using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Entities
{
    public class GroupDocumentType
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid TypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
