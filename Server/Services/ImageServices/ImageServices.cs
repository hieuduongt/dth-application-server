using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace DTHApplication.Server.Services.FileServices
{
    public class ImageServices : IImageServices
    {
        private readonly DBContext _dbContext;
        public ImageServices(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly string FILEEXTENSIONPATTERN = @"(?i)\.(png|jpg|jpeg|avif|webp|[^\.]+)$";

        public async Task<GenericResponse<Image>> Upload(IFormFile image)
        {
            if (image.Length > 0)
            {
                Image returnImage = new Image();
                try
                {
                    Guid imageId = Guid.NewGuid();
                    Regex reg = new Regex(FILEEXTENSIONPATTERN);
                    MatchCollection fileExtensionMatcher = reg.Matches(image.FileName);
                    string extension = fileExtensionMatcher[0].Value;
                    var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images"));
                    string fullPath = $"/Images/{imageId}{extension}";
                    var stream = System.IO.File.Create($"{filePath}/{imageId}{extension}");

                    await image.CopyToAsync(stream);
                    stream.Close();
                    returnImage.Id = imageId;
                    returnImage.URL = fullPath;
                    return new GenericResponse<Image>()
                    {
                        Code = 201,
                        IsSuccess = true,
                        Message = "Uploaded!",
                        Result = returnImage
                    };
                }
                catch(Exception ex)
                {
                    Delete(returnImage);
                    return new GenericResponse<Image>()
                    {
                        Code = 500,
                        IsSuccess = false,
                        Message = $"Error when uploading: {ex.Message}",
                        Result = null
                    };
                }
            } else
            {
                return new GenericResponse<Image>()
                {
                    Code = 400,
                    IsSuccess = false,
                    Message = "File is invalid!",
                    Result = null
                };
            }
        }

        public async Task<GenericListResponse<Image>> UploadMany(IFormFileCollection images)
        {
            if(images != null && images.Count > 0)
            {
                List<Image> uploadedImages = new List<Image>();
                try
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        if (images[i].Length > 0)
                        {
                            Guid imageId = Guid.NewGuid();
                            Regex reg = new Regex(FILEEXTENSIONPATTERN);
                            MatchCollection fileExtensionMatcher = reg.Matches(images[i].FileName);
                            string extension = fileExtensionMatcher[0].Value;
                            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images"));
                            string fullPath = $"/Images/{imageId}{extension}";
                            var stream = System.IO.File.Create($"{filePath}/{imageId}{extension}");

                            await images[i].CopyToAsync(stream);
                            Image image = new Image()
                            {
                                Id = imageId,
                                URL = fullPath,
                                IsMainImage = i == 0,
                            };
                            stream.Close();
                            uploadedImages.Add(image);
                        }
                    }
                    return new GenericListResponse<Image>
                    {
                        IsSuccess = true,
                        Code = 200,
                        Message = $"Uploaded {uploadedImages.Count} images",
                        Results = uploadedImages
                    };
                } catch(Exception ex)
                {
                    DeleteMany(uploadedImages);
                    return new GenericListResponse<Image>
                    {
                        IsSuccess = false,
                        Code = 500,
                        Message = $"Error when uploading the images: {ex.Message}",
                        Results = null
                    };
                }
                
            }
            else
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

        public GenericResponse DeleteMany(List<Image> images)
        {
            if(images != null && images.Count != 0) {
                try
                {
                    images.ForEach(img =>
                    {
                        string exitingFile = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images", img.URL.Replace("/Images/", "")));
                        System.IO.File.Delete(exitingFile);
                    });
                    return GenericResponse.Success("Deleted all related images");
                }
                catch (Exception ex)
                {
                    return GenericResponse.Success($"Error when deleteing images with error: {ex.Message}");
                }
            } else
            {
                return GenericResponse.Success("Your images are not valid!!!");
            }
        }

        public GenericResponse Delete(Image image)
        {
            if (image != null)
            {
                try
                {
                    string exitingFile = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images", image.URL.Replace("/Images/", "")));
                    System.IO.File.Delete(exitingFile);
                    return GenericResponse.Success("Deleted relate image");
                    
                }
                catch(Exception ex)
                {
                    return GenericResponse.Success($"Deleted 0 images with error: {ex.Message}");
                }
                
            }
            else
            {
                return GenericResponse.Success("Deleted 0 images! Your image is not valid");
            }
        }

        public async Task<GenericResponse> SetMainImage(Image image)
        {
            try
            {
                _dbContext.Images.Update(image);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Done");
            } catch (Exception ex)
            {
                return GenericResponse.Failed($"Error when changing main image: {ex.Message}");
            }
        }
    }
}
