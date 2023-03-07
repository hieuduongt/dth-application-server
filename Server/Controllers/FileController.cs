using DTHApplication.Server.Services.FileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileServices _fileServies;
        public FileController(IFileServices fileServies)
        {
            _fileServies = fileServies;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            var filesUploaded = await _fileServies.Upload(file);

            return Ok(filesUploaded);
        }

        [HttpPost("upload-many")]
        public async Task<IActionResult> UploadMany(IFormFileCollection files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Invalid file");
            }
            else
            {
                var filesUploaded = await _fileServies.UploadMany(files);

                return Ok(filesUploaded);
            }
        }
    }
}
