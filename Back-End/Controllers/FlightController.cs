using Application.Flights.Commands.CreateFlightCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Createflight(CreateFlightCommand command)
        {
            var fligh = await Mediator.Send(command);
            return Ok(fligh);
        }
    }
}
