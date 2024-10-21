using FlightSystem.Domain.Entities;
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
    public class UserRepository : IUserService // implement IUserService để xử lý code
    {
        private readonly FlightSystemDBContext _dbContext; // DI FlightSystemDBContext 
        public UserRepository(FlightSystemDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        // code xử lý thêm vào db
        public async Task<User> CreateUser(User user)
        {
          
            user.Create_at = DateTime.Now;
            user.Update_at = DateTime.Now;
            var groupUser = await _dbContext.Groups.FirstOrDefaultAsync(g => g.GroupId == user.GroupId); 
            if (groupUser == null)
            {
                throw new ArgumentException("group is null");
            }
            groupUser.Members += 1;
            await _dbContext.SaveChangesAsync();
            await _dbContext.Users.AddAsync(user);          
            await _dbContext.SaveChangesAsync();
            return user;
        }
        //code xử lý xóa user
        public async Task<bool> DeleteUser(Guid Id)
        {
            var userId = await _dbContext.Users
                                 .Include(u => u.Group).FirstOrDefaultAsync(u => u.UserId == Id);
            if (userId == null || userId.Group == null)
            {
                return false;
            }
            else
            {
              
                _dbContext.Users.Remove(userId);
                await _dbContext.SaveChangesAsync();
                userId.Group.Members -= 1;
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        // code xử lý lấy thông tin list user
        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }



        //code xử lý lấy thông tin user theo Id
        public async Task<User> GetUserById(Guid Id)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user),"user is null");
            }
            return user;
        }
        // code xử lý update user
        public async Task<User> UpdateUser(Guid Id, User user)
        {
            var userID = await _dbContext.Users.FindAsync(Id);
            if(userID == null)
            {
                throw new ArgumentNullException(nameof(user),"user is null");
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
        // lấy list user theo groupId
        public async Task<List<User>> GetUserByGroupId(Guid groupId)
        {
            var user = await _dbContext.Users.Where(u => u.GroupId == groupId).ToListAsync();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user),"user is null");
            }
            return user;
        }

        public async Task<List<User>> GetUserByActive(bool active)
        {
           var user = await _dbContext.Users.Where(u => u.IsActive == active).ToListAsync();
            if (user == null) 
            {
                throw new ArgumentNullException(nameof(user),"don't user");
            }
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var userEmail =await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userEmail == null)
            {
                throw new ArgumentNullException(nameof(userEmail), "don't user");

            }
            return userEmail;
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            var user = await _dbContext.Users.Where(u => u.Name!.Contains(name)).ToListAsync();
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user),"user name is null");
            }
            return user;
        }
    }
}
