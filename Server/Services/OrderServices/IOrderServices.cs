namespace DTHApplication.Server.Services.OrderServices
{
    public interface IOrderServices
    {
        public Task<GenericResponse<Order>> GetAsync(Guid id);
        public Task<GenericResponse<Pagination<Order>>> GetAllAsync(string? search, int page, int pageSize);
        public Task<GenericResponse> CreateAsync(OrderDTO orderProduct);
        public Task<GenericResponse> UpdateAsync(Order order);
    }
}
