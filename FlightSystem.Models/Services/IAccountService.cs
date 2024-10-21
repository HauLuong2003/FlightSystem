using FlightSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IAccountService
    {
      Task<User>  Login(User login);
      Task<bool> ChangePassword(User login);
      Task<bool> FrogetPassword(string Email);
    }
}
