using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class JwtTokenRepository : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                //yêu cầu là cặp khóa-giá trị chứa thông tin về người dùng
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //HMAC SHA-256 sẽ được sử dụng để ký mã thông báo, đây là thuật toán thường được sử dụng và an toàn cho JWT.
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"]
                ,claims: claims, expires:DateTime.Now.AddMinutes(2), signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt; 
        }
    }
}
