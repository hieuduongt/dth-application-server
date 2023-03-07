namespace DTHApplication.Server.Services.FileServices
{
    public interface IFileServices
    {
        public Task<GenericResponse<Image>> Upload(IFormFile file);
        public Task<GenericListResponse<Image>> UploadMany(IFormFileCollection files);
        public GenericResponse Delete(List<Image> images);
    }
}
