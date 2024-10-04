﻿using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : FlightSystemControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var logins = await Mediator.Send(login);
            return Ok(logins);

        }
    }
}
