using DTHApplication.Server.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTHApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<GenericResponse<Pagination<Order>>>> GetAll(string? search, int page = 1, int pageSize = 24)
        {
            var results = await _orderServices.GetAllAsync(search, page, pageSize);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<Order>>> Get(Guid id)
        {
            var results = await _orderServices.GetAsync(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(OrderDTO orderProduct)
        {
            var result = await _orderServices.CreateAsync(orderProduct);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> Update(Order order)
        {
            var result = await _orderServices.UpdateAsync(order);
            return Ok(result);
        }
    }
}
