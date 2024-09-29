using AutoMapper;

using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Models.Domain.DTOs;

namespace Back_End.Helper
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<Login, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(login => login.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(login => login.Password));
            
        }
    }
}
