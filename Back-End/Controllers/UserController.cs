﻿using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUserByActive;
using Application.Users.Queries.GetUserByGroupId;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.GetUserByName;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : FlightSystemControllerBase
    {
        // thêm mới user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand user)
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
        [HttpGet("userActive/{Active}")]
        public async Task<IActionResult> GetUserByActive(bool Active)
        {
            var users = await Mediator.Send(new GetUserByActive { IsActive = Active});
            return Ok(users);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName (string name)
        {
            var user = await Mediator.Send(new GetUserByNameQuery { Name = name });
            return Ok(user);
        }
    }
}
