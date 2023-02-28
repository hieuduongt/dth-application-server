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
        public async Task<GenericResponse> createAsync(Category category)
        {
            category.Id = Guid.NewGuid();
            var result = await _dbContext.Categories.AddAsync(category);
            if(result != null && result.State.Equals(EntityState.Added))
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Created succesfully"); ;
                
            } else
            {
                return GenericResponse.Success("Created Error"); ;
            }
        }

        public async Task<GenericResponse> deleteAsync(Guid Id)
        {
            Category category = new Category() { Id = Id };
            _dbContext.Categories.Attach(category);
            var result = _dbContext.Categories.Remove(category);
            if (result != null && result.State.Equals(EntityState.Deleted))
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Deleted succesfully"); ;

            }
            else
            {
                return GenericResponse.Success("Deleted Error"); ;
            }
        }

        public async Task<GenericListResponse<Category>> getAllAsync()
        {
            List<Category> categories = await _dbContext.Categories.ToListAsync();
            if(categories.Count() != 0)
            {
                return new GenericListResponse<Category>()
                {
                    Code = 200,
                    Message = "Get successfully",
                    IsSuccess = true,
                    Results = categories
                };
            } else
            {
                return new GenericListResponse<Category>()
                {
                    Code = 404,
                    Message = "No categories found",
                    IsSuccess = false,
                    Results = null
                };
            }
        }

        public async Task<GenericResponse<Category>> getAsync(Guid Id)
        {
            Category? category = await _dbContext.Categories.FindAsync(Id);
            return new GenericResponse<Category>()
            {
                Code = 200,
                IsSuccess = true,
                Message = "Get successfully",
                Result = category
            };
        }

        public async Task<GenericResponse> updateAsync(Category category)
        {
            _dbContext.Categories.Attach(category);
            var result = _dbContext.Categories.Update(category);
            if (result != null && result.State.Equals(EntityState.Modified))
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Updated succesfully"); ;

            }
            else
            {
                return GenericResponse.Success("Updated Error"); ;
            }
        }
    }
}
