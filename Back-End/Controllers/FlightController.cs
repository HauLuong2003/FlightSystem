using Application.Flights.Commands.CreateFlightCommand;
using Application.Flights.Queries.GetFlight;
using Application.Flights.Queries.GetFlightByNo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class FlightController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Createflight(CreateFlightCommand command)
        {
            var fligh = await Mediator.Send(command);
            return Ok(fligh);
        }
        [HttpGet]
        public async Task<IActionResult> GetFlight()
        {
            var flight = await Mediator.Send(new GetFlightQuery());
            return Ok(flight);
        }
        [HttpGet("{flightNo}")]
        public async Task<IActionResult> GetFlightByNo (string flightNo)
        {
            var flight = await Mediator.Send(new GetFlightByNoQuery { FlightNo = flightNo });
            return Ok(flight);
        }
    }
}
