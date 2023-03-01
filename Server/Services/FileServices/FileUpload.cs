using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace DTHApplication.Server.Services.FileServices
{
    public class FileUpload : IFileUpload
    {
        public FileUpload()
        {

        }

        private readonly string FILEEXTENSIONPATTERN = @"(?i)\.(png|jpg|jpeg|avif|webp|[^\.]+)$";

        public async Task<GenericResponse<Image>> Upload(IFormFile file)
        {
            if (file.Length > 0)
                {
                    Guid imageId = Guid.NewGuid();
                    Regex reg = new Regex(FILEEXTENSIONPATTERN);
                    MatchCollection fileExtensionMatcher = reg.Matches(file.FileName);
                    string extension = fileExtensionMatcher[0].Value;
                    var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images"));
                    string fullPath = $"/Images/{imageId}{extension}";
                    var stream = System.IO.File.Create($"{filePath}/{imageId}{extension}");
                    
                    await file.CopyToAsync(stream);
                    Image image = new Image() {
                        Id = imageId,
                        URL = fullPath,
                    };
                    stream.Close();
                return new GenericResponse<Image>()
                {
                    Code = 201,
                    IsSuccess = true,
                    Message = "Uploaded!",
                    Result = image
                };
            }

            return new GenericResponse<Image>() {
                Code = 500,
                IsSuccess = false,
                Message = "Cannot upload!",
                Result = null
            };
        }
    }
}
