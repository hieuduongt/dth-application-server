namespace DTHApplication.Server.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<GenericResponse> Register(UserRegister user);
        Task<GenericResponse<string>> Login(UserLogin user);
        Task<GenericResponse> ChangePassword(UserChangePW user);
    }
}
