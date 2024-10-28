using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountService
    {
        private readonly FlightSystemDBContext _dbContext;
        public AccountRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ChangePassword(User user)
        {
            var users = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (users == null) return false;
            
            else if (users.IsActive == true && users.VerificationCode == null)
            {
                users.Password = user.Password;
                users.PasswordSalt = user.PasswordSalt;
                users.Update_at = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> FrogetPassword(string Email)
        {
            // kiễm tra email có tồn tại hay không
            var userEmail = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            // trả về kết quả
            if (userEmail == null) 
            {
                return false;
            }
            else if(userEmail.IsActive == true)
            {
                return true;
            }
            return false;
        }

        public async Task<User> GetUserRefreshToken(string RefreshToken)
        {
           var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.RefreshToken == RefreshToken);
            if (user == null)
            {
                throw new ArgumentNullException("RefreshToken is null");
            }
            return user;
        }

        public async Task<User> Login(string Email)
        {
            var account = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (account == null)
            {
                throw new ArgumentNullException("user is null");
            }
            else if ( account.IsActive == false)
            {
                throw new ArgumentException(" account don't active");
            }
            return account;
        }

        public async Task UpdateActiveAccount(Guid Id, bool Active)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            if (user == null)
            {
                throw new ArgumentNullException("user is null");
            }
            user.IsActive = Active;
            user.Update_at = DateTime.Now;
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateRefreshToken(Guid Id, string RefreshToken)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            if (user == null)
            {
                throw new ArgumentNullException("user is null");
            }
            user.RefreshToken = RefreshToken;
            await _dbContext.SaveChangesAsync();
        }
    }
}
