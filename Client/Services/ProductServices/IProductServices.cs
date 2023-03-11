
namespace DTHApplication.Client.Services.ProductServices
{
    public interface IProductServices
    {
        public Pagination<Product> Products { get; set; }
        public Task<GenericResponse<Product>> GetAsync(Guid id);
        public Task GetAllAsync();
        public Task CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task<GenericResponse> DeleteAsync(Guid id);
    }
}
