using DTHApplication.Server.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServies _servies;
        public CategoryController(ICategoryServies servies)
        {
            _servies = servies;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<GenericListResponse<Category>>> GetAll()
        {
            var results = await _servies.getAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<Category>>> Get(Guid Id)
        {
            var results = await _servies.getAsync(Id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> CreateCategory(Category category)
        {
            var results = await _servies.createAsync(category);
            return Ok(results);
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> UpdateCategory(Category category)
        {
            var results = await _servies.updateAsync(category);
            return Ok(results);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<GenericResponse>> DeleteCategory(Guid Id)
        {
            var results = await _servies.deleteAsync(Id);
            return Ok(results);
        }
    }
}
