
using FlightSystem.Domain.Domain.Entities;
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
            if (users == null)
            {
                return false;
            }
            users.Password = user.Password;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FrogetPassword(string Email)
        {
            // kiễm tra email có tồn tại hay không
            var userEmail = await _dbContext.Users.AnyAsync(u => u.Email == Email);
           // trả về kết quả
            return userEmail;
        }

        public async Task<User> Login(User login)
        {
            var account = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account),"user is null");
            }
            else if (account.Password != login.Password || account.IsActive == false)
            {
                throw new ArgumentNullException(nameof(account), "login don't success");
            }
            return account;
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

    }
}
