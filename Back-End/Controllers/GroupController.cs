using Application.Groups.Commands.CreateGroup;
using Application.Groups.Commands.DeleteGroup;
using Application.Groups.Commands.UpdateGroup;
using Application.Groups.Queries.GetGroup;
using Application.Groups.Queries.GetGroupById;
using FlightSystem.Domain.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]// chỉ có admin mới thực hiện được
    public class GroupController : FlightSystemControllerBase
    {

        // tao moi group
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        {
            // lấy thông creator từ Jwt
            var creator = User.FindFirst(ClaimTypes.Email);
            if (creator == null)
            {
                return Forbid();
            }
            //gán creator  vào command 
            command.Creator = creator.Value;
            var group = await Mediator.Send(command);
            return Ok(group);
        }
        // lay list group
        [HttpGet]
        public async Task<IActionResult> GetGroup()
        {
            var groups = await Mediator.Send(new GetGroupQuery());
            return Ok(groups);
        }
        // lay group by id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGroupById(Guid Id)
        {
            var group = await Mediator.Send(new GetGroupByIdQuery{ GroupId = Id});
            return Ok(group);
        }
        // update group 
        [HttpPut("{Id}")] 
        public async Task<IActionResult> UpdateGroup(Guid Id, UpdateGroupCommand command)
        {
            if(Id != command.GroupId)
            {
                return BadRequest();
            }
            var group = await Mediator.Send(command);
            return Ok(group);
        }
       
        // delete group
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGroup(Guid Id)
        {
            var group = await Mediator.Send(new DeleteGroupCommand {Id =  Id});
            return Ok(group);
        }
    }
}
