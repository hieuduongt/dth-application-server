using Microsoft.Identity.Client;

namespace DTHApplication.Server.Services.ProductServices
{
    public interface IProductServices
    {
        public Task<GenericResponse<Product>> getAsync(Guid Id);
        public Task<GenericListResponse<Product>> getByCategoryAsync(Guid Id);
        public Task<GenericListResponse<Product>> getAllAsync();
        public Task<GenericResponse> createAsync(Product Product);
        public Task<GenericResponse> updateAsync(Product Product);
        public Task<GenericResponse> deleteAsync(Guid Id);
    }
}
