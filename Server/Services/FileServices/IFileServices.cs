namespace DTHApplication.Server.Services.FileServices
{
    public interface IFileServices
    {
        public Task<GenericResponse<Image>> Upload(IFormFile file);
        public Task<GenericListResponse<Image>> Upload(IFormFileCollection files);
        public GenericResponse Delete(List<Image> images);
    }
}
