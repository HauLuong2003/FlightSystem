using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly FlightSystemDBContext _dbContext;
        public UserRepository(FlightSystemDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            user.Create_at = DateTime.Now;
            await _dbContext.Users.AddAsync(user);          
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Guid> DeleteUser(Guid Id)
        {
            var userId = await _dbContext.Users.FindAsync(Id);
            if (userId == null)
            {
                throw new NotImplementedException("Id is null");
            }
            _dbContext.Users.Remove(userId);
            _dbContext.SaveChanges();
            return Id;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid Id)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            if (user == null)
            {
                throw new NotImplementedException("not found");
            }
            return user;
        }

        public async Task<User> UpdateUser(Guid Id, User user)
        {
            var userID = await _dbContext.Users.FindAsync(Id);
            if(userID == null)
            {
                throw new NotImplementedException("user is null");
            }
            userID.Name = user.Name;          
            userID.Password = user.Password;
            userID.Email = user.Email;
            userID.Phone = user.Phone;
            userID.IsActive = user.IsActive;
            userID.Update_at = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return userID;
        }
    }
}
