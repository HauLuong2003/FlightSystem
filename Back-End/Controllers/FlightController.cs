using Application.Flights.Commands.CreateFlightCommand;
using Application.Flights.Commands.DeleteFlightCommand;
using Application.Flights.Commands.UpdateFlightCommand;
using Application.Flights.Queries.GetFlight;
using Application.Flights.Queries.GetFlightById;
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFlightById (Guid Id)
        {
            var flight = await Mediator.Send(new GetFlightByIdQuery { Id = Id });
            return Ok(flight);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFlight(Guid Id, UpdateFlightCommand command)
        {
            var flight = await Mediator.Send(command);
            return Ok(flight);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(Guid Id)
        {
            var flight = await Mediator.Send(new DeleteFlightCommand { Id = Id });
            return Ok(flight);
        }
    }
}
