using Application.Account.ChangePasswordCommand;
using Application.Account.ForgetPasswordCommand;
using Application.Account.LoginCommand;
using Application.Account.ResetPassWord;
using Application.Account.VerificationToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthoController : FlightSystemControllerBase
    {

        [HttpPost]
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
        [HttpPost("Email")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPassWordCommand command)
        {
            var emailsend = await Mediator.Send(command);
            return Ok(emailsend);
        }
        [Authorize(Policy = "Verification")]
        [HttpPost("Token")]
        public async Task<IActionResult> Verification ([FromBody] VerificationTokenCommand command)
        {
            var verification = await Mediator.Send(command);
            return Ok(verification);
        }
        [HttpPost, Authorize(Policy = "Verification")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassWordCommand command)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            command.Email = email;
            var verification = await Mediator.Send(command);
            return Ok(verification);
        }
    }
}
