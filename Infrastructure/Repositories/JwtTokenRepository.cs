using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class JwtTokenRepository : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly FlightSystemDBContext _dbContext;

        public JwtTokenRepository(IConfiguration configuration, FlightSystemDBContext dbContext) 
        {
            _configuration = configuration;
            _dbContext = dbContext;
            
        }

        public async Task<string> GenerateToken(User user)
        {
            //Lấy permission từ group của user
            var permission = await _dbContext.Users
                    .Where(u => u.Email == user.Email)
                    .Select(g => g.Group!.Premisstion!.Permission_Name)
                     .FirstOrDefaultAsync();
            var role = await _dbContext.Users.Where(u => u.UserId == user.UserId)
                        .Select(g => g.Group!.Group_Name).FirstOrDefaultAsync();
            List<Claim> claims = new List<Claim>
            {
                //yêu cầu là cặp khóa-giá trị chứa thông tin về người dùng
                // payload
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Permission" , permission ?? "no permission"),
                new Claim("GroupId", user.GroupId.ToString()),
                new Claim(ClaimTypes.Role, role ?? "user")
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            //HMAC SHA sẽ được sử dụng để ký mã thông báo, đây là thuật toán thường được sử dụng và an toàn cho JWT.
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims,
                            expires: DateTime.Now.AddMinutes(60), 
                            signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt; 
        }

        public async Task<string> GenerateTokenVerification(string Email)
        {

            List<Claim> claims = new List<Claim>
            {
                //yêu cầu là cặp khóa-giá trị chứa thông tin về người dùng
                // payload
                 new Claim(ClaimTypes.Email, Email),
                 new Claim("Permission" , "Verification"),
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            //HMAC SHA sẽ được sử dụng để ký mã thông báo, đây là thuật toán thường được sử dụng và an toàn cho JWT.
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims,
                            expires: DateTime.Now.AddMinutes(15),
                            signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

      
    }
}
