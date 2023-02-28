namespace DTHApplication.Server.Services.CategoryServices
{
    public interface ICategoryServies
    {
        public Task<GenericResponse<Category>> getAsync(Guid Id);
        public Task<GenericListResponse<Category>> getAllAsync();
        public Task<GenericResponse> createAsync(Category category);
        public Task<GenericResponse> updateAsync(Category category);
        public Task<GenericResponse> deleteAsync(Guid Id);
    }
}
