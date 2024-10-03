using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : FlightControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var logins = await Mediator.Send(login);
            return Ok(logins);

        }
    }
}
