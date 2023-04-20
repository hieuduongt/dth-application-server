using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace DTHApplication.Client.Services.ProductServices
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _http;
        public UserServices(HttpClient http)
        {
            _http = http;
        }

        public Pagination<User> Users { get; set; } = new Pagination<User>();
        public string ResponseMessage { get; set; } = string.Empty;

        public async Task GetAllAsync()
        {
            var response = await _http.GetAsync("api/user/all");
            Console.WriteLine(response);
            if(response.StatusCode.Equals(HttpStatusCode.Forbidden)) {
                ResponseMessage = "You does not have permission to access this resource";
            } else {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<GenericResponse<Pagination<User>>>(content,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ResponseMessage = string.Empty;
                Users = users.Result;
            }       
        }

        public Task<GenericResponse<User>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            var result = await _http.PostAsJsonAsync("api/user/update", user);
            var json = await result.Content.ReadFromJsonAsync<GenericResponse>();
            if(json != null && json.IsSuccess == true) {
                await GetAllAsync();
            } else {
                ResponseMessage = json.Message;
            }
        }
    }
}
