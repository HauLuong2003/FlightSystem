using Application.Account.Query.Captcha;
using Application.Account.Command.ChangePasswordCommand;
using Application.Account.Command.ForgetPasswordCommand;
using Application.Account.Command.LoginCommand;
using Application.Account.Command.ResetPassWord;
using Application.Account.Command.VerificationToken;
using Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        //[HttpPost("Refresh-Token")]
        //public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];
        //    var refreshTokenExpires = Request.Cookies["refreshTokenExpires"];
          
        //    if (string.IsNullOrEmpty(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token."); 
        //    }

        //    else if (DateTime.TryParse(refreshTokenExpires, out DateTime expires) && expires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired."); // Token đã hết hạn
        //    }

        //    var token = await Mediator.Send(command);
        //    return Ok(token);
        //}
    }
}
