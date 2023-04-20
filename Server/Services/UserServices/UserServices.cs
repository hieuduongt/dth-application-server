using DTHApplication.Shared;
using Microsoft.EntityFrameworkCore;

namespace DTHApplication.Server.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly DBContext _dbContext;
        public UserServices(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenericResponse<Pagination<User>>> GetAllAsync(string? search, int page, int pageSize)
        {
            search ??= "";
            var users = await _dbContext.Users
                .Where(u => u.LoginName.ToLower().Contains(search.ToLower()) 
                || u.Email.ToLower().Contains(search.ToLower())
                || u.UserName.ToLower().Contains(search.ToLower())
                || u.Address.ToLower().Contains(search.ToLower())
                )
                .Include(u => u.ProfileImages)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new User
            {
                Id = u.Id,
                UserName = u.UserName,
                AccountStatus = u.AccountStatus,
                Address = u.Address,
                CreatedDate = u.CreatedDate,
                DateOfBirth = u.DateOfBirth,
                Email = u.Email,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                LoginName = u.LoginName,
                Role = u.Role,
                ProfileImages = u.ProfileImages,
                UpdatedDate = u.UpdatedDate
            }).ToListAsync();
            return new GenericResponse<Pagination<User>>
            {
                Code = 200,
                Message = "Get successfully",
                Result = new Pagination<User>
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalPages = (await GetNumberOfUsersBySearchText(search) + pageSize - 1) / pageSize,
                    TotalRecords = await GetNumberOfUsersBySearchText(search),
                    Results = users
                },
                IsSuccess = true
            };
        }

        public async Task<GenericResponse<User>> GetAsync(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return new GenericResponse<User>
            {
                Code = 200,
                IsSuccess = true,
                Message = "Get successfully",
                Result = user
            };
        }

        public async Task<GenericResponse> UpdateAsync(UserUpdate user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);
            currentUser.AccountStatus = user.AccountStatus;
            currentUser.Address = user.Address;
            currentUser.UpdatedDate = DateTime.Now;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.Role = user.Role;
            _dbContext.Users.Update(currentUser);
            try
            {
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Update user profile!");
            } catch (Exception ex)
            {
                return GenericResponse.Failed($"Failed when updating user profile: {ex.Message}");
            }
        }

        public async Task<int> GetNumberOfUsersBySearchText(string searchText)
        {
            try
            {
                return await _dbContext.Users
                    .Where(u => u.LoginName.ToLower().Contains(searchText.ToLower())
                        || u.Email.ToLower().Contains(searchText.ToLower())
                        || u.UserName.ToLower().Contains(searchText.ToLower())
                        || u.Address.ToLower().Contains(searchText.ToLower())
                        )
                    .Include(p => p.ProfileImages)
                    .CountAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
