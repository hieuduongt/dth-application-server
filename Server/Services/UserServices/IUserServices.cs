namespace DTHApplication.Server.Services.UserServices
{
    public interface IUserServices
    {
        Task<GenericResponse<Pagination<User>>> GetAllAsync(string? search, int page, int pageSize);
        Task<GenericResponse<User>> GetAsync(Guid id);
        Task<GenericResponse> UpdateAsync(User user);
    }
}
