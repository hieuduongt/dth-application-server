using System.Net;
using System.Net.Http.Json;

namespace DTHApplication.Client.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _http;
        public ProductServices(HttpClient http)
        {
            _http = http;
        }

        public Pagination<Product> Products { get; set; } = new Pagination<Product>();

        public Task CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }
        public async Task<GenericResponse> DeleteAsync(Guid id)

        {
            var response = await _http.DeleteAsync($"api/product/{id}");
            if(response != null && response.IsSuccessStatusCode)
            {
                return GenericResponse.Success("Deleted product");
            } else
            {
                return GenericResponse.Failed("Cannot delete product");
            }
        }

        public async Task GetAllAsync()
        {
            var products = await _http.GetFromJsonAsync<GenericResponse<Pagination<Product>>>("api/product/all");
            if (products != null && products.IsSuccess)
            {
                Products = products.Result!;
            }
        }

        public async Task<GenericResponse<Product>> GetAsync(Guid Id)
        {
            var response = await _http.GetFromJsonAsync<GenericResponse<Product>>($"api/product/{Id}");
            if(response != null && response.Result != null)
            {
                return response;
            } else
            {
                return response;
            }
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
