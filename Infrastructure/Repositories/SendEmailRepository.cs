using FlightSystem.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SendEmailRepository : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly FlightSystemDBContext _dbContext;
        public SendEmailRepository(IConfiguration configuration, FlightSystemDBContext dBContext)
        {
            _configuration = configuration;
            _dbContext = dBContext;
        }
        public async Task<bool> SendEmail(string email)
        {
            try
            {
                var Email = new MimeMessage();
                // add email gửi nội dung
                Email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
                // email nhận nội dung
                Email.To.Add(MailboxAddress.Parse(email));
                // tieu de 
                Email.Subject = "Your verification code";
                Random random = new Random();
                // random 6 số ngẫu nhiên
                string verificationCode = random.Next(100000, 999999).ToString();
                //noi dung email
                Email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) 
                { 
                    Text = $"Your verification code is: {verificationCode}" 
                };
                // gán mã vào database
                var emailVerification = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (emailVerification == null)
                {
                    return false;
                }
                emailVerification.VerificationCode = verificationCode;
                await _dbContext.SaveChangesAsync();
                using (var smtp = new SmtpClient())
                {
                    // Connect to the SMTP server
                    await smtp.ConnectAsync(_configuration.GetSection("Email:Host").Value, 587, SecureSocketOptions.StartTls);

                    await smtp.AuthenticateAsync(_configuration.GetSection("Email:UserName").Value, _configuration.GetSection("Email:PassWord").Value);
                    await smtp.SendAsync(Email);
                    await smtp.DisconnectAsync(true);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> VerificationToken(string email,string Verification)
        {
            var user =await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            else if(user.VerificationCode == Verification)
            {
                // xác nhận đúng thì gán giá trị null vào vì sau này còn sử dụng
                user.VerificationCode = null;
                await _dbContext.SaveChangesAsync();
                return true;
            }
           return false;
        }
    }
}
