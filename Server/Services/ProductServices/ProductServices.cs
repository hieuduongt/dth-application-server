using DTHApplication.Server.Services.CategoryServices;
using DTHApplication.Server.Services.FileServices;
using DTHApplication.Shared;
using DTHApplication.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
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

        public async Task<GenericResponse> CreateAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            if (product.ImageURLs != null && product.ImageURLs.Count != 0)
            {
                product.ImageURLs[0]!.IsMainImage = true;
                product.ImageURLs.ForEach(img =>
                {
                    img.ProductId = product.Id;
                    if (img.Id == new Guid())
                    {
                        img.Id = Guid.NewGuid();
                    }
                });
            }
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Created succesfully");
            }
            catch (Exception ex)
            {

                return GenericResponse.Failed("Create failed with error: " + ex.Message);
            }
        }

        public async Task<GenericResponse> DeleteAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.Include(p => p.ImageURLs).Where(p => p.Id == id).FirstAsync();
                _dbContext.Products.Remove(product);
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
            catch (Exception ex)
            {
                return GenericResponse.Failed("Delete failed with error: " + ex.Message);
            }
        }

        public async Task<GenericResponse<Product>> GetAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.Where(p => p.Id == id).Include(p => p.ImageURLs).Include(p => p.Category).FirstAsync();
                return new GenericResponse<Product>
                {
                    Message = "Get successfully",
                    Code = 200,
                    IsSuccess = true,
                    Result = product
                };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Product>
                {
                    Message = "Your product does not exist with error: " + ex.Message,
                    Code = 404,
                    IsSuccess = false,
                    Result = null
                };
            }
        }

        public async Task<GenericResponse<Pagination<Product>>> GetAllAsync(string? search, int page, int pageSize)
        {
            try
            {
                search ??= "";
                List<Product> Products = await _dbContext.Products
                    .Where(p => p.ProductName.Contains(search) || p.Description.Contains(search))
                    .Include(p => p.ImageURLs)
                    .Include(p => p.Category)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        ImageURLs = p.ImageURLs,
                        Description = p.Description,
                        Category = p.Category,
                        CategoryId = p.CategoryId
                    }).ToListAsync();

                return new GenericResponse<Pagination<Product>>
                {
                    Code = 200,
                    Message = "Get successfully",
                    Result = new Pagination<Product>
                    {
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalPages = (await GetNumberOfProductsBySearchText(search) + pageSize - 1) / pageSize,
                        TotalRecords= await GetNumberOfProductsBySearchText(search),
                        Results = Products
                    },
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Pagination<Product>>
                {
                    Code = 500,
                    Message = "Get failed with error: " + ex.Message,
                    Result = null,
                    IsSuccess = false
                };
            }

        }

        public async Task<GenericResponse> UpdateAsync(Product product)
        {
            var originalImages = await _dbContext.Images.Where(i => i.ProductId == product.Id).ToListAsync();
            var newImages = product.ImageURLs;
            var shouldBeDeletedImages = originalImages.FindAll(img => newImages.Find(ni => ni.Id == img.Id) == null);
            _dbContext.Images.RemoveRange(originalImages);
            _dbContext.Images.AddRange(newImages);
            _dbContext.Products.Update(product);
            try
            {
                await _dbContext.SaveChangesAsync();
                _fileServies.Delete(shouldBeDeletedImages);
                return GenericResponse.Success("Updated product!");
            }
            catch (Exception ex)
            {
                return GenericResponse.Failed($"Update failed: " + ex.Message);
            }
        }

        public async Task<GenericResponse<Pagination<Product>>> GetByCategoryAsync(Guid categoryId, string? search, int page, int pageSize)
        {
            try
            {
                search ??= "";
                List<Product> products = await _dbContext.Products
                    .Where(p => p.CategoryId == categoryId)
                    .Where(p => p.ProductName.Contains(search) || p.Description.Contains(search))
                    .Include(p => p.Category)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        ImageURLs = p.ImageURLs,
                        Description = p.Description,
                        Category = p.Category,
                        CategoryId = p.CategoryId
                    }).ToListAsync();
                return new GenericResponse<Pagination<Product>>
                {
                    Code = 200,
                    Message = "Get successfully",
                    Result = new Pagination<Product>
                    {
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalPages = (await GetNumberOfProductsByCategoryAndSearchText(categoryId, search) + pageSize - 1) / pageSize,
                        TotalRecords = await GetNumberOfProductsByCategoryAndSearchText(categoryId, search),
                        Results = products
                    },
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Pagination<Product>>()
                {
                    Code = 500,
                    Message = "Get failed: " + ex.Message,
                    IsSuccess = false,
                    Result = null
                };
            }

        }

        public async Task<int> GetNumberOfProductsBySearchText(string searchText)
        {
            try
            {
                return await _dbContext.Products
                    .Where(p => p.ProductName.Contains(searchText) || p.Description.Contains(searchText))
                    .Include(p => p.ImageURLs)
                    .Include(p => p.Category)
                    .CountAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> GetNumberOfProductsByCategoryAndSearchText(Guid categoryId, string searchText)
        {
            try
            {
                return await _dbContext.Products
                    .Where(p => p.CategoryId == categoryId)
                    .Where(p => p.ProductName.Contains(searchText) || p.Description.Contains(searchText))
                    .Include(p => p.Category)
                    .CountAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
