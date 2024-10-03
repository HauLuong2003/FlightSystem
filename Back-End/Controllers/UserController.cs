using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUserByGroupId;
using Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FlightControllerBase
    {
        // thêm mới user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand user)
        {
            var create = await Mediator.Send(user);
            return Ok(create);
        }
        //xóa user theo Id
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            var delete = await Mediator.Send(new DeleteUserCommand { Id = Id });
            return Ok(delete);
        }
        //lấy thông tin theo user id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery { Id = Id });
            return Ok(user);
        }
        //lấy thông tin List user
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await Mediator.Send(new GetUserAllQuery());
            return Ok(users);
        }
        //update thông tin user
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(Guid Id, UpdateUserCommand user)
        {
            if (Id != user.UserId)
            {
                return BadRequest();
            }
            var userId = await Mediator.Send(user);
            return Ok(userId);
        }
        //lấy thông tin user từ groupId
        [HttpGet("groupId/{Id}")]
        public async Task<IActionResult> GetUserByGroupId(Guid Id)
        {
            var users = await Mediator.Send(new GetUserByGroupQuery { GroupId = Id });
            return Ok(users);
        }
    }
}
