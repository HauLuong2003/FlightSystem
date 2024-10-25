using Application.Documents.Commands.CreateDocumentCommand;
using Application.Documents.Commands.DeleteDocumentCommand;
using Application.Documents.Commands.UpdateDocumentCommand;
using Application.Documents.Queries.CheckDocumentAccess;
using Application.Documents.Queries.GetDocument;
using Application.Documents.Queries.GetDocumentByName;
using Application.Documents.Queries.GetDocumentByType;
using Application.Documents.Queries.GetDocumetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DocumentController : FlightSystemControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocument command)
        {
            //lấy thông tin creator từ jwt 
            var creator = User.FindFirst(ClaimTypes.Email);
            if (creator == null)
            {
                return BadRequest();
            }
            //sau đó gán và command
            command.Creator = creator.Value;
            var document = await Mediator.Send(command);
            return Ok(document);
        }
        //update document
        
        [HttpPut("{Id}"), Authorize]
        public async Task<IActionResult> UpdateDocument(Guid Id, UpdateDocumentCommand command)
        {
            if (Id != command.DocumentId)
            {
                return BadRequest();
            }
            // Nếu là Admin thì được thực hiện 
            if(User.IsInRole("Admin"))
            {
                var document = await Mediator.Send(command);
                return Ok(document);
            }
            //Nếu khác admin kiễm tra xem Document vs goup có được phép truy cập
            else
            {
                // lấy goupId từ claim 
                var groupID = User.FindFirst("GroupId");
                //lấy permisson từ claim
                var permisson = User.FindFirst("permisson")?.ToString();
               
                if (groupID == null || permisson == null)
                {
                    return Unauthorized("Group or Permission information is missing from the token.");
                }
                var groupId = Guid.Parse(groupID.Value);
                // gửi sang Handler để xử lý
                var groupHasAccess = await Mediator.Send(new CheckDocumentAccessQuery { DocumentId = Id, GroupId = groupId });
                if (groupHasAccess == false)
                {
                    return Forbid("Your group does not have access to this document.");
                }
                // Kiễm tra permission xem có được Write không
                else if (permisson == "Read Only" || permisson == "No Permission")
                {
                    // Trả về không cho phép truy cập
                    return Forbid("Your  does not have access to this document.");
                }
                
                var document = await Mediator.Send(command);
                return Ok(document);
            }
           
        }
        // lay list document
        [Authorize(Policy = "AdminReadAndWrite")]
        [HttpGet]
        public async Task<IActionResult> GetDocumet()
        {
            var document = await Mediator.Send(new GetDocumentQuery());
            return Ok(document);
        }
        [Authorize]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDocument(Guid Id)
        {
            // Nếu là Admin thì được thực hiện 
            if (User.IsInRole("Admin"))
            {
                var document = await Mediator.Send(new DeleteDocumentCommand { DocumentId = Id });
                return Ok(document);
            }
            //Nếu khác admin kiễm tra xem Document vs goup có được phép truy cập
            else
            {
                // lấy goupId từ claim 
                var groupID = User.FindFirst("GroupId");
                //lấy permisson từ claim
                var permisson = User.FindFirst("permisson")?.ToString();

                if (groupID == null || permisson == null)
                {
                    return Unauthorized("Group or Permission information is missing from the token.");
                }
                var groupId = Guid.Parse(groupID.Value);
                // gửi sang Handler để xử lý
                var groupHasAccess = await Mediator.Send(new CheckDocumentAccessQuery { DocumentId = Id, GroupId = groupId });
                if (groupHasAccess == false)
                {
                    return Forbid("Your group does not have access to this document.");
                }
                // Kiễm tra permission xem có được Write không
                else if (permisson == "Read Only" || permisson == "No Permission")
                {
                    // Trả về không cho phép truy cập
                    return Forbid("Your group does not have access to this document.");
                }
              
                var document = await Mediator.Send(new DeleteDocumentCommand { DocumentId = Id });
                return Ok(document);
            }
        }
        [Authorize(Policy = "AdminReadAndWrite")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDocumentById(Guid Id)
        {
            var groupID = User.FindFirst("GroupId");
            var groupId = Guid.Parse(groupID!.Value);
            // gửi sang Handler để xử lý
            var groupHasAccess = await Mediator.Send(new CheckDocumentAccessQuery { DocumentId = Id, GroupId = groupId });
            if (groupHasAccess == false)
            {
                return Forbid("Your group does not have access to this document.");
            }
            var document = await Mediator.Send(new GetDocumentByIdQuery { DocumentId = Id });
            return Ok(document);
        }
        //lay document theo ten
        [Authorize(Policy = "AdminReadAndWrite")]
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetDocumentByName(string Name)
        {
            var document = await Mediator.Send(new GetDocumentByNameQuery { Name = Name });
            return Ok(document);
        }
        [Authorize(Policy = "AdminReadAndWrite")]
        [HttpGet("Type/{TypeId}")]
        public async Task<IActionResult> GetDocumentByType(Guid TypeId)
        {
            var document = await Mediator.Send(new GetDocumentByType { TypeId = TypeId });
            return Ok(document);
        }
    }
}
