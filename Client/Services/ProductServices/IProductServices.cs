
namespace DTHApplication.Client.Services.ProductServices
{
    public interface IProductServices
    {
        public List<Product> Products { get; set; }
        public Task<GenericResponse<Product>> getAsync(Guid Id);
        public Task getAllAsync();
        public Task createAsync(Product Product);
        public Task updateAsync(Product Product);
        public Task<GenericResponse> deleteAsync(Guid Id);
    }
}
