using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Domain.Entities
{
    public class GroupDocument
    {
        
        public Guid GroupId { get; set; }   
        public Group Group { get; set; }  // Navigation property to Group
       
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }  // Navigation property to Document

    }
}
