using DTHApplication.Server.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("all")]
        public async Task<ActionResult<GenericResponse<Pagination<User>>>> GetAllUser(string? search, int page = 1, int pageSize = 24)
        {
            var results = await _userServices.GetAllAsync(search, page, pageSize);
            return Ok(results);
        }

        [HttpPost("update")]
        public async Task<ActionResult<GenericResponse>> UpdateUser(UserUpdate user)
        {
            var results = await _userServices.UpdateAsync(user);
            return Ok(results);
        }
    }
}
