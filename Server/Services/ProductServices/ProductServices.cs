using DTHApplication.Server.Services.CategoryServices;
using DTHApplication.Server.Services.FileServices;
using DTHApplication.Shared;
using DTHApplication.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DTHApplication.Server.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly DBContext _dbContext;
        private readonly IFileServices _fileServies;
        public ProductServices(DBContext dbContext, IFileServices fileServies)
        {
            _dbContext = dbContext;
            _fileServies = fileServies;
        }

        public async Task<GenericResponse> createAsync(Product Product)
        {
            Product.Id = Guid.NewGuid();
            if (Product.ImageURLs != null && Product.ImageURLs.Count != 0)
            {
                Product.ImageURLs[0]!.IsMainImage = true;
                Product.ImageURLs.ForEach(img =>
                {
                    img.ProductId = Product.Id;
                    if (img.Id == new Guid())
                    {
                        img.Id = Guid.NewGuid();
                    }
                });
            }

            var result = await _dbContext.Products.AddAsync(Product);
            if (result != null && result.State.Equals(EntityState.Added))
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Created succesfully");
            }
            else
            {
                return GenericResponse.Failed("Create Failed");
            }
        }

        public async Task<GenericResponse> deleteAsync(Guid Id)
        {
            var product = await _dbContext.Products.Include(p => p.ImageURLs).Where(p => p.Id == Id).FirstAsync();
            if (product != null)
            {
                var result = _dbContext.Products.Remove(product);
                if (result != null && result.State.Equals(EntityState.Deleted))
                {
                    var imagesDeletingResults = _fileServies.Delete(product.ImageURLs);
                    if (imagesDeletingResults.IsSuccess == true)
                    {
                        await _dbContext.SaveChangesAsync();
                        return GenericResponse.Success("Delete succesfully");
                    }
                    else
                    {
                        return GenericResponse.Failed("Delete Failed, your images are not exist!");
                    }
                }
                else
                {
                    return GenericResponse.Failed("Delete Failed");
                }
            }
            else
            {
                return GenericResponse.Failed("Delete Failed, your product does not exist!");
            }
        }

        public async Task<GenericResponse<Product>> getAsync(Guid Id)
        {
            var result = new GenericResponse<Product>();
            try
            {
                var product = await _dbContext.Products.Where(p => p.Id == Id).Include(p => p.ImageURLs).Include(p => p.Category).FirstAsync();
                result.Message = "Get successfully";
                result.Code = 200;
                result.IsSuccess = true;
                result.Result = product;
            }
            catch (Exception ex)
            {
                result.Message = "Your product does not exist with error: " + ex.Message;
                result.Code = 404;
                result.IsSuccess = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GenericListResponse<Product>> getAllAsync()
        {
            try
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
            } catch (Exception ex)
            {
                return new GenericListResponse<Product>(500, "GetFailed " + ex.Message, null, false);;
            }
            
        }

        public async Task<GenericResponse> updateAsync(Product Product)
        {
            var originalImages = await _dbContext.Images.Where(i => i.ProductId == Product.Id).ToListAsync();
            var newImages = Product.ImageURLs;
            var shouldBeDeletedImages = originalImages.FindAll(img => newImages.Find(ni => ni.Id == img.Id) == null);
            _dbContext.Images.RemoveRange(originalImages);
            _dbContext.Images.AddRange(newImages);
            _dbContext.Products.Update(Product);
            try
            {
                await _dbContext.SaveChangesAsync();
                _fileServies.Delete(shouldBeDeletedImages);
                return GenericResponse.Success("Updated product!");
            } catch (Exception ex)
            {
                return GenericResponse.Failed($"Update failed: " + ex.Message);
            }   
        }

        public async Task<GenericListResponse<Product>> getByCategoryAsync(Guid Id)
        {
            try
            {
                List<Product> products = await _dbContext.Products.Where(p => p.CategoryId == Id).Include(p => p.Category).Select(p => new Product
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageURLs = p.ImageURLs,
                    Description = p.Description,
                    Category = p.Category,
                    CategoryId = p.CategoryId
                }).ToListAsync();
                return new GenericListResponse<Product>()
                {
                    Code = 200,
                    Message = "Get successfully",
                    IsSuccess = true,
                    Results = products
                };
            } catch (Exception ex)
            {
                return new GenericListResponse<Product>()
                {
                    Code = 500,
                    Message = "Get failed: " + ex.Message,
                    IsSuccess = false,
                    Results = null
                };
            }
            
        }
    }
}
