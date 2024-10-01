using Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FlightControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand user)
        {
            var users = await Mediator.Send(user);
            return Ok(users);
        }
    }
}
