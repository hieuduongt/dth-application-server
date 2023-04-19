using DTHApplication.Server.Services.FileServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices _imageServies;
        public ImageController(IImageServices imageServies)
        {
            _imageServies = imageServies;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            var filesUploaded = await _imageServies.Upload(file);

            return Ok(filesUploaded);
        }

        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultiple(IFormFileCollection files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Invalid file");
            }
            else
            {
                var filesUploaded = await _imageServies.UploadMany(files);

                return Ok(filesUploaded);
            }
        }
    }
}
