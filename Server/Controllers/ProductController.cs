using DTHApplication.Server.Services;
using DTHApplication.Shared;
using DTHApplication.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<GenericListResponse<Product>>> GetAllProducts() 
        {
            GenericListResponse<Product> results = await _services.getAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<Product>>> GetProduct(Guid Id)
        {
            GenericResponse<Product> results = await _services.getAsync(Id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> CreateProduct(Product product)
        {
            GenericResponse results = await _services.createAsync(product);
            return Ok(results);
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> UpdateProduct(Product product)
        {
            GenericResponse results = await _services.updateAsync(product);
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse>> DeleteProduct(Guid Id)
        {
            GenericResponse results = await _services.deleteAsync(Id);
            return Ok(results);
        }
    }
}
