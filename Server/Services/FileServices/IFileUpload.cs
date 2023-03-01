namespace DTHApplication.Server.Services.FileServices
{
    public interface IFileUpload
    {
        public Task<GenericResponse<Image>> Upload(IFormFile file);
    }
}
