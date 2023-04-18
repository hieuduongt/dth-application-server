using DTHApplication.Server.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<ActionResult<GenericResponse>> Register(UserRegister user)
        {
            var result = await _authServices.Register(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<GenericResponse>> Login(UserLogin user)
        {
            var result = await _authServices.Login(user);
            return Ok(result);
        }
    }
}
