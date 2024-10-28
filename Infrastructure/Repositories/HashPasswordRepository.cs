using FlightSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HashPasswordRepository : IHashPassword
    {
        //tạo mật khẩu mã băm
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
           using(var hmac = new HMACSHA512())
           {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordHash = Convert.ToBase64String(hashBytes);
           }
        }
        // xác nhận mật khẩu mã băm
        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            //Đây là giá trị salt duy nhất được sử dụng để băm mật khẩu trong quá trình đăng ký. Nó đang được chuyển đổi từ chuỗi được mã hóa Base64 thành một mảng byte.
            using (var hmac = new HMACSHA512(Convert.FromBase64String(passwordSalt)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //nó được chuyển đổi trở lại thành một mảng byte.
                var passwordHashBytes =  Convert.FromBase64String(passwordHash);
                // Phương pháp được sử dụng để so sánh computedHash(băm của mật khẩu do người dùng cung cấp) với passwordHashBytes(băm đã lưu trữ).
                return computedHash.SequenceEqual(passwordHashBytes);// trả về true or false
            }
        }
    }
}
