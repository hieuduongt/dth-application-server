using Microsoft.Identity.Client;

namespace DTHApplication.Server.Services.ProductServices
{
    public interface IProductServices
    {
        public Task<GenericResponse<Product>> GetAsync(Guid id);
        public Task<GenericResponse<Pagination<Product>>> GetByCategoryAsync(Guid categoryId, string? search, int page, int pageSize);
        public Task<GenericResponse<Pagination<Product>>> GetAllAsync(string? search, int page, int pageSize);
        public Task<GenericResponse> CreateAsync(Product product);
        public Task<GenericResponse> UpdateAsync(Product product);
        public Task<GenericResponse> DeleteAsync(Guid id);
    }
}
