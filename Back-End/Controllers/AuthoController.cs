using Application.Account.ChangePasswordCommand;
using Application.Account.LoginCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : FlightSystemControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var logins = await Mediator.Send(login);
            return Ok(logins);

        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var resetPass = await Mediator.Send(command);
            return Ok(resetPass);
        }
    }
}
