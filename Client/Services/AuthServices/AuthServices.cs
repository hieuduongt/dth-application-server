using System.Net.Http.Json;

namespace DTHApplication.Client.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly HttpClient _httpClient;
        public AuthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GenericResponse<string>> LoginAsync(UserLogin user)
        {
            var results = await _httpClient.PostAsJsonAsync("api/auth/login", user);
            var json = await results.Content.ReadFromJsonAsync<GenericResponse<string>>();
            return json ?? new GenericResponse<string>();
        }
    }
}
