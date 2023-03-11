namespace DTHApplication.Server.Services.CategoryServices
{
    public interface ICategoryServies
    {
        public Task<GenericResponse<Category>> GetAsync(Guid id);
        public Task<GenericListResponse<Category>> GetAllAsync();
        public Task<GenericResponse> CreateAsync(Category category);
        public Task<GenericResponse> UpdateAsync(Category category);
        public Task<GenericResponse> DeleteAsync(Guid id);
    }
}
