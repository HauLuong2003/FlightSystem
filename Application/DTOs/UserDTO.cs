using Application.Common.Mapping;
using FlightSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    
    public class UserDTO : IMapFrom<User>//interface được sử dụng để ánh xạ từ entity User sang UserDTO thông qua AutoMapper.
    {
        public Guid UserId { get; set; }
      
        public string Name { get; set; } = string.Empty;
       
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public bool IsActive { get; set;}
        public Guid GroupId { get; set;}
        public DateTime? Create_at { get; set;}
        public DateTime? Update_at { get; set;}
    }
}
