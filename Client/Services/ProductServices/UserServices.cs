using System.Net;
using System.Net.Http.Json;

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

        public async Task GetAllAsync()
        {
            var users = await _http.GetFromJsonAsync<GenericResponse<Pagination<User>>>("api/user/all");
            if(users != null && users.IsSuccess && users.Result != null) {
                Users = users.Result;
            }
        }

        public Task<GenericResponse<User>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
