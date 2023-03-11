using DTHApplication.Shared;

namespace DTHApplication.Server.Services.CategoryServices
{
    public class CategoryServies : ICategoryServies
    {
        private readonly DBContext _dbContext;
        public CategoryServies(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GenericResponse> CreateAsync(Category category)
        {
            category.Id = Guid.NewGuid();
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Created succesfully");
            }
            catch (Exception ex)
            {
                return GenericResponse.Success("Create failed with error: " + ex.Message);
            }
        }

        public async Task<GenericResponse> DeleteAsync(Guid id)
        {
            try
            {
                Category? category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                _dbContext.Categories.Remove(category!);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Deleted succesfully");
            }
            catch (Exception ex)
            {
                return GenericResponse.Success("Delete failed with error: " + ex.Message);
            }
        }

        public async Task<GenericListResponse<Category>> GetAllAsync()
        {
            try
            {
                List<Category> categories = await _dbContext.Categories.ToListAsync();
                return new GenericListResponse<Category>
                {
                    Code = 200,
                    Message = "Get successfully",
                    IsSuccess = true,
                    Results = categories
                };
            }
            catch (Exception ex)
            {
                return new GenericListResponse<Category>()
                {
                    Code = 404,
                    Message = "No categories found with error: " + ex.Message,
                    IsSuccess = false,
                    Results = null
                };
            }
        }

        public async Task<GenericResponse<Category>> GetAsync(Guid id)
        {
            try
            {
                Category? category = await _dbContext.Categories.FindAsync(id);
                return new GenericResponse<Category>()
                {
                    Code = 200,
                    IsSuccess = true,
                    Message = "Get successfully",
                    Result = category
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Category>()
                {
                    Code = 404,
                    IsSuccess = false,
                    Message = "No category found with error: " + ex.Message,
                    Result = null
                };
            }

        }

        public async Task<GenericResponse> UpdateAsync(Category category)
        {
            try
            {
                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Updated succesfully");
            } catch (Exception ex)
            {
                return GenericResponse.Failed("Update failed with error: " + ex.Message);
            }
        }
    }
}
