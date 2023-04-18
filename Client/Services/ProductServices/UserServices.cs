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

        public Pagination<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
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
