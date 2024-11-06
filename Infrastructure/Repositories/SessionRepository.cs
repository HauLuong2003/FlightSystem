using Application.Common.InterfaceService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionRepository(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string? GetSessionValue(string key)
        {
            return _contextAccessor.HttpContext?.Session.GetString(key);
        }

        public void SetSessionValue(string key, string value)
        {
            _contextAccessor.HttpContext?.Session.SetString(key, value);
        }
    }
}
