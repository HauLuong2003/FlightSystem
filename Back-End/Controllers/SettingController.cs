using Application.Settings.Commands.CreateSetting;
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
        [HttpPost]
        public async Task<IActionResult> CreateSetting(CreateSettingCommand command)
        {
            var id = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (id == null)
            {
                return BadRequest();
            }
            var userId = Guid.Parse(id);
            command.userId = userId;
            var setting = await Mediator.Send(command);
            return Ok(setting);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSetting(UpdateSettingCommand command)
        {
            var setting = await Mediator.Send(command);
            return Ok(setting);
        }
        [HttpGet]
        public async Task<IActionResult> GetSetting()
        {
            var id = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (id == null)
            {
                return BadRequest();
            }
            var userId = Guid.Parse(id);
            var setting = await Mediator.Send(new GetSettingQuery { UserId = userId });
            return Ok(setting);
        }
    }
}
