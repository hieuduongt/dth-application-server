using DTHApplication.Shared;

namespace DTHApplication.Server.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly DBContext _dbContext;
        public OrderServices(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GenericResponse> CreateAsync(OrderDTO orderProduct)
        {
            if (orderProduct != null && orderProduct.ProductIds.Count != 0)
            {
                try
                {
                    var order = new Order
                    {
                        Id = Guid.NewGuid(),
                        Address = orderProduct.Address,
                        OrderDate = orderProduct.OrderDate,
                        DateOfReceipt = orderProduct.DateOfReceipt,
                        Status = orderProduct.Status,
                        TotalPrice = orderProduct.TotalPrice
                    };
                    order.Status = Status.Ordered;
                    order.Id = Guid.NewGuid();
                    for (int i = 0; i < orderProduct.ProductIds.Count; i++)
                    {
                        var product = await _dbContext.Products.FindAsync(orderProduct.ProductIds[i]);
                        var newOrderProduct = new OrderProduct { Order = order, Product = product! };
                        await _dbContext.Orders.AddAsync(order);
                        await _dbContext.OrderProducts.AddAsync(newOrderProduct);
                    }
                    await _dbContext.SaveChangesAsync();
                    return GenericResponse.Success("Ordered");
                }
                catch (Exception ex)
                {
                    return GenericResponse.Failed("Error occurred: " + ex.Message);
                }
            }
            else
            {
                return GenericResponse.Failed("Error when processing your order! the product you are looking for may no longer available!");
            }
        }

        public async Task<GenericResponse<Pagination<Order>>> GetAllAsync(string? search, int page, int pageSize)
        {
            search ??= "";
            var orders = await _dbContext.Orders
                .Where(o => o.OrderProduct.Where(op => op.Product.ProductName.Contains(search)).Count() != 0)
                .Include(o => o.OrderProduct)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ImageURLs)
                .Select(o => new Order
                {
                    Id = o.Id,
                    Address = o.Address,
                    DateOfReceipt = o.DateOfReceipt,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    OrderProduct = o.OrderProduct
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new GenericResponse<Pagination<Order>>
            {
                Code = 200,
                IsSuccess = true,
                Message = "Get successfully",
                Result = new Pagination<Order>
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    Results = orders,
                    TotalPages = (await GetNumberOfOrdersBySearchText(search) + pageSize - 1) / pageSize,
                    TotalRecords = await GetNumberOfOrdersBySearchText(search)
                }
            };
        }

        public async Task<GenericResponse<Order>> GetAsync(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            return new GenericResponse<Order>
            {
                Code = 200,
                IsSuccess = true,
                Message = "Get successfully",
                Result = order!
            };
        }

        public async Task<GenericResponse> UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            try
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Updated the order");
            }
            catch (Exception ex)
            {
                return GenericResponse.Failed("Error when processing your order with error: " + ex.Message);
            }

        }
        public async Task<int> GetNumberOfOrdersBySearchText(string searchText)
        {
            try
            {
                return await _dbContext.Orders
                .Where(o => o.OrderProduct.Where(op => op.Product.ProductName.Contains(searchText)).Count() != 0)
                .Include(o => o.OrderProduct)
                .ThenInclude(p => p.Product)
                .Select(o => new Order
                {
                    Id = o.Id,
                    Address = o.Address,
                    DateOfReceipt = o.DateOfReceipt,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    OrderProduct = o.OrderProduct
                })
                .CountAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
