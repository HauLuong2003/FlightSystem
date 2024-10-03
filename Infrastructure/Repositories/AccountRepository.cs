
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


            public async Task<bool> Login(User login)
            {
            var email = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            var password = await _dbContext.Users.FirstOrDefaultAsync(s => s.Password == login.Password);
            if (email == null || password == null)
            {
                return false;
            }

            return true;
        }
    }
}
