using Application.Common.Mapping;
using FlightSystem.Domain.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    // truyền dữ liệu  giữa Controller và Service.
    public class UserDTO : IMapFrom<User>//interface được sử dụng để ánh xạ từ entity User sang UserDTO thông qua AutoMapper.
    {
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set;}
        public Guid GroupId {  get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }
    }
}
