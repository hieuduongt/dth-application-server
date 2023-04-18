namespace DTHApplication.Server.Services.FileServices
{
    public interface IImageServices
    {
        public Task<GenericResponse<Image>> Upload(IFormFile image);
        public Task<GenericListResponse<Image>> UploadMany(IFormFileCollection images);
        public GenericResponse Delete(Image image);
        public GenericResponse DeleteMany(List<Image> images);
        public Task<GenericResponse> SetMainImage(Image image);
    }
}
