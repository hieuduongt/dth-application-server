using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace DTHApplication.Server.Services.FileServices
{
    public class FileServices : IFileServices
    {
        public FileServices()
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

        public async Task<GenericListResponse<Image>> UploadMany(IFormFileCollection files)
        {
            if(files != null && files.Count > 0)
            {
                List<Image> uploadedImages = new List<Image>();
                foreach (var file in files)
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
                        Image image = new Image()
                        {
                            Id = imageId,
                            URL = fullPath,
                        };
                        stream.Close();
                        uploadedImages.Add(image);
                    }
                }
                return new GenericListResponse<Image>
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = $"Uploaded {uploadedImages.Count} files",
                    Results = uploadedImages
                };
            } else
            {
                return new GenericListResponse<Image>
                {
                    IsSuccess = false,
                    Code = 400,
                    Message = "Your files are not valid, please double-check your files!",
                    Results = null
                };
            }
        }

        public GenericResponse Delete(List<Image> images)
        {
            if(images != null && images.Count != 0) {
                images.ForEach(img =>
                {
                    string exitingFile = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images", img.URL.Replace("/Images/","")));
                    System.IO.File.Delete(exitingFile);
                });
                return GenericResponse.Success("Deleted all related images");
            } else
            {
                return GenericResponse.Success("Deleted 0 images!!!");
            }
        }
    }
}
