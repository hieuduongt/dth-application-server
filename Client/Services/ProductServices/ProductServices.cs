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

        public List<Product> Products { get; set; } = new List<Product>();

        public Task createAsync(Product Product)
        {
            throw new NotImplementedException();
        }
        public async Task<GenericResponse> deleteAsync(Guid Id)

        {
            var response = await _http.DeleteAsync($"api/product/{Id}");
            if(response != null && response.IsSuccessStatusCode)
            {
                return GenericResponse.Success("Deleted product");
            } else
            {
                return GenericResponse.Failed("Cannot delete product");
            }
        }

        public async Task getAllAsync()
        {
            var products = await _http.GetFromJsonAsync<GenericListResponse<Product>>("api/product/getall");
            if (products != null && products.Results != null)
            {
                Products = products.Results;
            }
        }

        public async Task<GenericResponse<Product>> getAsync(Guid Id)
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

        public Task updateAsync(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
