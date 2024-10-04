using Application.Documents.Commands.CreateDocumentCommand;
using Application.Documents.Commands.DeleteDocumentCommand;
using Application.Documents.Commands.UpdateDocumentCommand;
using Application.Documents.Queries.GetDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : FlightSystemControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDocument(CreateDocumentCommand command)
        {
            var document = await Mediator.Send(command);
            return Ok(document);
        }
        //update document
        [HttpPut]
        public async Task<IActionResult> UpdateDocument(Guid Id, UpdateDocumentCommand command)
        {
            if (Id != command.DocumentId)
            {
                return BadRequest("Id don't ");
            }
            var document = await Mediator.Send(command);
            return Ok(document);
        }
        // lay list document
        [HttpGet]
        public async Task<IActionResult> GetDocumet()
        {
            var document = await Mediator.Send(new GetDocumentQuery());
            return Ok(document);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDocument(Guid Id)
        {
            var document = await Mediator.Send(new DeleteDocumentCommand { DocumentId = Id });
            return Ok(document);
        }
    }
}
