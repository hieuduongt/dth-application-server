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

        public IActionResult Image()
        {

        }
    }
}
