using DTHApplication.Server.Services.FileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileUpload _fileUpload;
        public FileController(IFileUpload fileUpload)
        {
            _fileUpload = fileUpload;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            var filesUploaded = await _fileUpload.Upload(file);

            return Ok(filesUploaded);
        }
    }
}
