using FlightSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public  class CaptchaRepsitory : ICaptchaService
    {
        // tạo captcha xác nhận
        public string GenerateRandomText()
        {
            // gồm có chữ và số
            //là hằng số, và không thể thay đổi giá trị sau khi khai báo.
            const string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            const string digits = "0123456789";
            var random = new Random();
            //var text = Enumerable.Repeat(chars ,6).
            //        Select(s => s[random.Next(6)]).ToArray();
            //string result = Convert.ToString(text)!;
            //return result;
            //s: Tham chiếu đến chuỗi  trong mỗi lần lặp.
            // tạo 2 số ngẫu nhiên
            var numbers = Enumerable.Repeat(digits,2)
                            .Select(s => s[random.Next(2)]).ToList();
            //Phương thức random.Next() trả về một số nguyên ngẫu nhiên nằm trong khoảng từ 0 đến s.Length - 1
            // tạo 4 chữ ngẫu nhiên
            var chars = Enumerable.Repeat(letters,4)
                        .Select(s => s[random.Next(4)]).ToList();
            // nôi chuỗi lại
            chars.AddRange(numbers);
            // random ngẫu nhiên lại
            chars = chars.OrderBy(c => random.Next()).ToList();
         
            // thành một mảng các ký tự (char[]).
            return new string(chars.ToArray());
        }

        public (byte[], string) GenerateCaptcha(string text)
        {
            //Hình ảnh này có kích thước 150 pixel chiều rộng và 50 pixel chiều cao.
            // cảnh báo về nền tản, nếu sử dụng window sẽ không sao 
            // sử dụng SkiaSharp để có thể chạy đa nền tản
            Bitmap bitmap = new Bitmap(150, 50);
            //tạo một đối tượng Graphics có thể vẽ lên bitmap vừa tạo.
            Graphics g = Graphics.FromImage(bitmap);
            //tô toàn bộ bitmap bằng màu trắng.
            g.Clear(Color.White);
            //Arial: Phông chữ sử dụng là Arial.
            //20: Kích thước font là 20 điểm.
            //FontStyle.Bold:font được sử dụng là in đậm(Bold).
            Font font = new Font("Comic Sans MS", 20, FontStyle.Bold);
            g.DrawString(text, font, Brushes.Black, 10, 10);
            // Đối tượng này sẽ được dùng để tạo ra các điểm ảnh (noise) ngẫu nhiên trên hình ảnh CAPTCHA.
            Random random = new Random();
            //Vòng lặp này chạy 30 lần để tạo ra 30 điểm nhiễu (noise) ngẫu nhiên trên hình ảnh CAPTCHA.
            for (int i = 0; i < 30; ++i)
            {
                //lấy một giá trị ngẫu nhiên cho tọa độ x trong khoảng từ 0 đến bitmap.Width - 1 (trong trường hợp này là từ 0 đến 149).
                int x = random.Next(0, bitmap.Width);
                //Lấy một giá trị ngẫu nhiên cho tọa độ y trong khoảng từ 0 đến bitmap.Height - 1(trong trường hợp này là từ 0 đến 49).
                int y = random.Next(0, bitmap.Height);
                // Đặt màu cho điểm ảnh (pixel) tại vị trí (x, y) thành màu đen. Điều này tạo ra các điểm nhiễu trên hình ảnh CAPTCHA để làm cho hình ảnh khó bị nhận dạng tự động.
                bitmap.SetPixel(x, y, Color.Black);

            }
            // cung cấp một luồng dữ liệu lưu trữ trong bộ nhớ. Luồng này sẽ lưu trữ hình ảnh CAPTCHA dưới dạng byte để có thể trả về.
            using (MemoryStream ms = new MemoryStream())
            {
                //Lưu hình ảnh bitmap vào luồng bộ nhớ (memory stream) với định dạng PNG.
                bitmap.Save(ms, ImageFormat.Png);
                return (ms.ToArray(), text);//Trả về một tuple chứa hai giá trị:
            }
        }
    }
}
