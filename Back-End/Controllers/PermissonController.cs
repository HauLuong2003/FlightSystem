using Application.Permissions.Commands.CreatePermisson;
using Application.Permissions.Commands.DeletePermisson;
using Application.Permissions.Commands.UpdatePermission;
using Application.Permissions.Queries.GetPermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class PermissonController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePermisson([FromBody] CreatePermissionCommand command)
        {
            var permission = await Mediator.Send(command);
            return Ok(permission);
        }
        [HttpGet]
        public async Task<IActionResult> GetPermisson()
        {
            var permission = await Mediator.Send(new GetPermissionQuery());
            return Ok(permission);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePermisson(UpdatePermissionCommand command)
        {
            var permission = await Mediator.Send(command);
            return Ok(permission);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePermission(Guid Id)
        {
            var permission = await Mediator.Send(new DeletePermissonCommand { Id = Id});
            return Ok(permission);
        }
    }
}
