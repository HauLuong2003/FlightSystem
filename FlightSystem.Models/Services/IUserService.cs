using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(Guid Id);
        Task<bool> DeleteUser(Guid Id);
        Task<User> UpdateUser(Guid Id,User user);
        Task<User> CreateUser(User user);
        Task<List<User>> GetUserByGroupId(Guid groupId);
        Task<List<User>> GetUserByActive(bool active);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetUserByName(string name);
        
    }
}
