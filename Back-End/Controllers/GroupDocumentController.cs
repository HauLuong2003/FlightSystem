﻿using Application.Documents.Commands.CreateGroupDocumentCommand;
using Application.Documents.Commands.DeleteGroupDocument;
using Application.Documents.Commands.UpdateGroupDocumentCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupDocumentController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGroupDocument (CreateGroupDocumentCommand command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGroupDocument(UpdateGroupDocumentCommand command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGroupDocument(DeleteGroupDocumentCommand command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
    }
}