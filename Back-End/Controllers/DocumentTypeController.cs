﻿
using Application.DocumentTypes.Commands.CreateDocumentTypeCommand;
using Application.DocumentTypes.Commands.DeleteDocumentTypeCommand;
using Application.DocumentTypes.Commands.UpdateDocumentTypeCommand;
using Application.DocumentTypes.Queries.CheckDocumentTypeAccess;
using Application.DocumentTypes.Queries.GetDocumentType;
using Application.DocumentTypes.Queries.GetDocumentTypeId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : FlightSystemControllerBase
    {

        [Authorize(Policy = "AdminWrite")]
        [HttpPost]
        public async Task<IActionResult> CreateDocumentType([FromBody] CreateDocumentTypeCommand command)
        {
            //lấy creator từ jwt là email
            var creator = User.FindFirst(ClaimTypes.Email);
            if (creator == null)
            {
                return Forbid();
            }
            // sau đó gán vào command
            command.Creator = creator.Value;
            var documentType = await Mediator.Send(command);
            return Ok(documentType);
        }

        [Authorize(Policy = "AdminReadAndWrite")]
        [HttpGet]
        public async Task<IActionResult> GetDocumentType()
        {
            var documentType = await Mediator.Send(new GetDocumentTypeQuery());
            return Ok(documentType);
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDocumentTypeById(Guid Id)
        {
            // Nếu là Admin thì được thực hiện 
            if (User.IsInRole("Admin"))
            {
                var documentType = await Mediator.Send(new GetDocumentTypeIdQuery { Id = Id });
                return Ok(documentType);
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
                // Kiễm tra permission xem có được Write không
                if (permisson == "Read Only" || permisson == "No Permission")
                {
                    // Trả về không cho phép truy cập
                    return Forbid("Your group does not have access to this document.");
                }
                var groupId = Guid.Parse(groupID.Value);
                // gửi sang Handler để xử lý
                var groupHasAccess = await Mediator.Send(new CheckDocumentTypeAccessQuery { TypeId = Id, GroupId = groupId });
                if (groupHasAccess == false)
                {
                    return Forbid("Your group does not have access to this document.");
                }
                var documentType = await Mediator.Send(new GetDocumentTypeIdQuery { Id = Id });
                return Ok(documentType);

            }
        }
        [Authorize]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDocumentType(Guid Id)
        {
            if (User.IsInRole("Admin"))
            {
                var documentType = await Mediator.Send(new DeleteDocumentTypeCommand { Id = Id });
                return Ok(documentType);
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
                // Kiễm tra permission xem có được Write không
                if (permisson == "Read Only" || permisson == "No Permission")
                {
                    // Trả về không cho phép truy cập
                    return Forbid("Your group does not have access to this document.");
                }
                var groupId = Guid.Parse(groupID.Value);
                // gửi sang Handler để xử lý
                var groupHasAccess = await Mediator.Send(new CheckDocumentTypeAccessQuery { TypeId = Id, GroupId = groupId });
                if (groupHasAccess == false)
                {
                    return Forbid("Your group does not have access to this document.");
                }
                var documentType = await Mediator.Send(new DeleteDocumentTypeCommand { Id = Id });
                return Ok(documentType);
            }
        }

        
      
        [Authorize]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDocumentType(Guid Id,UpdateDocumentTypeCommand command)
        {
            if(Id != command.TypeId)
            {
                return BadRequest("Id aren't the same");
            }
            if (User.IsInRole("Admin"))
            {
                var documentType = await Mediator.Send(command);
                return Ok(documentType);
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
                // Kiễm tra permission xem có được Write không
                if (permisson == "Read Only" || permisson == "No Permission")
                {
                    // Trả về không cho phép truy cập
                    return Forbid("Your group does not have access to this document.");
                }
                var groupId = Guid.Parse(groupID.Value);
                // gửi sang Handler để xử lý
                var groupHasAccess = await Mediator.Send(new CheckDocumentTypeAccessQuery { TypeId = Id, GroupId = groupId });
                if (groupHasAccess == false)
                {
                    return Forbid("Your group does not have access to this document.");
                }
                var documentType = await Mediator.Send(command);
                return Ok(documentType);
            }
          
        }
    }
}
