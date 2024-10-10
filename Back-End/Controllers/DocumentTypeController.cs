using Application.Documents.Queries.GetDocument;
using Application.Documents.Queries.GetDocumetById;
using Application.DocumentTypes.Commands.CreateDocumentTypeCommand;
using Application.DocumentTypes.Commands.DeleteDocumentTypeCommand;
using Application.DocumentTypes.Commands.UpdateDocumentTypeCommand;
using Application.DocumentTypes.Queries.GetDocumentType;
using Application.DocumentTypes.Queries.GetDocumentTypeId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class DocumentTypeController : FlightSystemControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDocumentType()
        {
            var documentType = await Mediator.Send(new GetDocumentTypeQuery());
            return Ok(documentType);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDocumentTypeById(Guid Id)
        {
            var documentType = await Mediator.Send(new GetDocumentTypeIdQuery{ Id = Id });
            return Ok(documentType);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDocumentType(Guid Id)
        {
            var documentType = await Mediator.Send(new DeleteDocumentTypeCommand { Id = Id });
            return Ok(documentType);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDocumentType(CreateDocumentTypeCommand command)
        {
            var documentType = await Mediator.Send(command);
            return Ok(documentType);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDocumentType(Guid Id,UpdateDocumentTypeCommand command)
        {
            if(Id != command.TypeId)
            {
                return BadRequest("Id aren't the same");
            }
            var documentType = await Mediator.Send(command);
            return Ok(documentType);
        }
    }
}
