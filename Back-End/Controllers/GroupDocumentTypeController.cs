using Application.DocumentTypes.Commands.CreateDocumentTypeCommand;
using Application.DocumentTypes.Commands.DeleteGroupDocumentType;
using Application.DocumentTypes.Commands.UpdateGroupDocumentType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupDocumentTypeController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGroupDocumentType(CreateDocumentTypeCommand command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGroupDocumentType (UpdateGroupDocumentType command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGroupDocumentType(DeleteGroupDocumentTypeCommand command)
        {
            var groupDocument = await Mediator.Send(command);
            return Ok(groupDocument);
        }
    }
}
