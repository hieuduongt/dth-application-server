﻿
namespace DTHApplication.Client.Services.ProductServices
{
    public interface IUserServices
    {
        public string ResponseMessage { get; set; }
        public Pagination<User> Users { get; set; }
        public Task<GenericResponse<User>> GetAsync(Guid id);
        public Task GetAllAsync();
        public Task UpdateAsync(User user);
    }
}
