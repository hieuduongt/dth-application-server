namespace DTHApplication.Client.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<GenericResponse<string>> LoginAsync(UserLogin user);
    }
}
