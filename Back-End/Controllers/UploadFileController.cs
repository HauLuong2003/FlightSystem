using Application.Documents.Commands.CreateFileDucument;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminWrite")]
    public class UploadFileController : FlightSystemControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //kiễm tra file có null và có gì trị gì ko
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");// nếu ko thì trả về no file
            }
            //được tạo ra để tạm thời giữ nội dung của tệp đang được tải lên
            using (var memoryStream = new MemoryStream()) 
            {
                await file.CopyToAsync(memoryStream);
                var filedata = memoryStream.ToArray();
                var saveCommand = new SaveFileCommand()
                {
                    FileData = filedata,
                    FileName = file.FileName,
                    ContentType = file.ContentType
                };
                var path = await Mediator.Send(saveCommand);
                return Ok(path);
            }
         
        }
    }
}
