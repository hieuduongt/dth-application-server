using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet("all")]
        public async Task<ActionResult<GenericResponse<Pagination<Product>>>> GetAll(string? search, int page = 1, int pageSize = 24)
        {
            GenericResponse<Pagination<Product>> results = await _services.GetAllAsync(search, page, pageSize);
            return Ok(results);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<GenericResponse<Pagination<Product>>>> GetAllByCategory(Guid id, string? search, int page = 1, int pageSize = 24)
        {
            GenericResponse<Pagination<Product>> results = await _services.GetByCategoryAsync(id, search, page, pageSize);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<Product>>> Get(Guid id)
        {
            GenericResponse<Product> results = await _services.GetAsync(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(Product product)
        {
            GenericResponse results = await _services.CreateAsync(product);
            return Ok(results);
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> Update(Product product)
        {
            GenericResponse results = await _services.UpdateAsync(product);
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse>> Delete(Guid id)
        {
            GenericResponse results = await _services.DeleteAsync(id);
            return Ok(results);
        }
    }
}
