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

        [HttpGet("all")]
        public async Task<ActionResult<GenericListResponse<Category>>> GetAll()
        {
            var results = await _servies.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<Category>>> Get(Guid id)
        {
            var results = await _servies.GetAsync(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(Category category)
        {
            var results = await _servies.CreateAsync(category);
            return Ok(results);
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> Update(Category category)
        {
            var results = await _servies.UpdateAsync(category);
            return Ok(results);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<GenericResponse>> Delete(Guid id)
        {
            var results = await _servies.DeleteAsync(id);
            return Ok(results);
        }
    }
}
