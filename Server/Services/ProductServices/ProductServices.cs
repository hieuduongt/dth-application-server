using DTHApplication.Server.Services.CategoryServices;
using DTHApplication.Shared;

namespace DTHApplication.Server.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly DBContext _dbContext;
        private readonly ICategoryServies _categoriesServies;
        public ProductServices(DBContext dbContext, ICategoryServies categoriesServies)
        {
            _dbContext = dbContext;
            _categoriesServies = categoriesServies;
        }

        public async Task<GenericResponse> createAsync(Product Product)
        {
            Product.Id = Guid.NewGuid();
            Product.ImageURLs.ForEach(img => img.ProductId = Product.Id);
            var result = await _dbContext.Products.AddAsync(Product);
            return new GenericResponse() { Code = 200, IsSuccess= true, Message = "Created succesfully" };
        }

        public async Task<GenericResponse> deleteAsync(Guid Id)
        {
            var result = new GenericResponse();
            var product = await _dbContext.Products.FindAsync(Id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                result.Message = "Deleted successfully";
                result.Code = 201;
                result.IsSuccess = true;
            } else
            {
                result.Message = "Your product does not exist!";
                result.Code = 404;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<GenericResponse<Product>> getAsync(Guid Id)
        {
            var result = new GenericResponse<Product>();
            var product = await _dbContext.Products.Where(p => p.Id == Id).Include(p => p.ImageURLs).FirstAsync();
            if (product != null)
            {
                Category? category = await _dbContext.Categories.FindAsync(product.CategoryId);
                product.Category = category;
                result.Message = "Get successfully";
                result.Code = 200;
                result.IsSuccess = true;
                result.Result = product;
            }
            else
            {
                result.Message = "Your product does not exist!";
                result.Code = 404;
                result.IsSuccess = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GenericListResponse<Product>> getAllAsync()
        {
            List<Product> Products = await _dbContext.Products.Include(p => p.ImageURLs).Include(p => p.Category).Select(p => new Product
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageURLs = p.ImageURLs,
                    Description = p.Description,
                    Category = p.Category,
                    CategoryId = p.CategoryId
                }).ToListAsync();
            GenericListResponse<Product> results = new GenericListResponse<Product>(200, "Success", Products, true);
            return results;
        }

        public async Task<GenericResponse> updateAsync(Product Product)
        {
            var result = new GenericResponse();
            var product = await _dbContext.Products.FindAsync(Product.Id);
            if (product != null)
            {
                _dbContext.Products.Update(product);
                result.Message = "Updated successfully";
                result.Code = 201;
                result.IsSuccess = true;
            }
            else
            {
                result.Message = "Your product does not exist!";
                result.Code = 404;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<GenericListResponse<Product>> getByCategoryAsync(Guid Id)
        {
            List<Product> products = await _dbContext.Products.Where(p => p.CategoryId == Id).ToListAsync();
            return new GenericListResponse<Product>()
            {
                Code = 200,
                Message = "Get successfully",
                IsSuccess = true,
                Results = products
            };
        }
    }
}
