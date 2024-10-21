using Application.Settings.Commands.UpdateSetting;
using Application.Settings.Queries.GetSettingByUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingController : FlightSystemControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> UpdateSetting(UpdateSettingCommand command)
        {
            var setting = await Mediator.Send(command);
            return Ok(setting);
        }
        [HttpGet]
        public async Task<IActionResult> GetSetting()
        {

            var setting = await Mediator.Send(new GetSettingQuery());
            return Ok(setting);
        }
    }
}
