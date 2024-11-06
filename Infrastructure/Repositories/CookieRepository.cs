using Application.Common.InterfaceService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CookieRepository : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetCookie(string key, string value, CookieOptions options)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, options);
        }
    }
}
