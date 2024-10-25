using Application.Account.Query.Captcha;
using Application.Account.Command.ChangePasswordCommand;
using Application.Account.Command.ForgetPasswordCommand;
using Application.Account.Command.LoginCommand;
using Application.Account.Command.ResetPassWord;
using Application.Account.Command.VerificationToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Account.Command.RefreshToken;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthoController : FlightSystemControllerBase
    {
       

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var logins = await Mediator.Send(login);
            return Ok(logins);

        }
        [HttpPost("ChangePassword"),Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            
            var resetPass = await Mediator.Send(command);
            return Ok(resetPass);
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPassWordCommand command)
        {
            var emailsend = await Mediator.Send(command);
            return Ok(emailsend);
        }
        [Authorize(Policy = "Verification")]
        [HttpPost("Token")]
        public async Task<IActionResult> Verification ([FromBody] VerificationTokenCommand command)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            command.Email = email;
            var verification = await Mediator.Send(command);
            return Ok(verification);
        }
        [HttpPost("ResetPassword"), Authorize(Policy = "Verification")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassWordCommand command)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            command.Email = email;
            var verification = await Mediator.Send(command);
            return Ok(verification);
        }

        [HttpGet("Captcha")]
        public async Task<IActionResult> GetCaptcha()
        {
            var captcha = await Mediator.Send(new GetCaptchaQuery());
            return Ok(captcha);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var refreshTokenExpires = Request.Cookies["refreshTokenExpires"];
        
            // Kiểm tra nếu không có refresh token
            if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(refreshTokenExpires))
            {
                return Unauthorized("No Refresh Token found.");
            }
            // Kiểm tra thời gian hết hạn

            if (!DateTime.TryParse(refreshTokenExpires, out var TokenExpires) || TokenExpires < DateTime.Now)
            {
                return Unauthorized("Refresh Token has expired.");
            }
            var RefreshToken = refreshToken!;
          
            var token = await Mediator.Send(new RefreshTokenCommand{ RefreshToken = RefreshToken });
            return Ok(token);
        }
        //[HttpPost("Logout"),Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //    var token = Request.Headers["Authorization"].ToString().Replace("Bearer ","");
        //    if(string.IsNullOrEmpty(token))
        //    {
        //        return BadRequest("Invalid token");
        //    }
        //    var userId = User.FindFirstValue("UserId");
        //    var Id = Guid.Parse(userId);
        //    await Mediator.Send(new LogoutCommand { Token = token, Id = Id });
        //    return Ok("Logged out successfully");
        //}
    }
}
