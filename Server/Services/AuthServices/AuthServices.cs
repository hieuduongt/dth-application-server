using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DTHApplication.Server.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly DBContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthServices(DBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<GenericResponse<string>> Login(UserLogin user)
        {
            if (await UserExist(user.UserName, user.UserName))
            {
                var currentUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.LoginName.ToLower() == user.UserName.ToLower() || u.Email.ToLower() == user.UserName.ToLower());
                if(VerifyPasswordHash(user.Password, currentUser.PasswordHash, currentUser.PasswordSalt))
                {
                    return new GenericResponse<string>
                    {
                        Code = 200,
                        IsSuccess = true,
                        Message = "Login successfully!",
                        Result = CreateUserToken(currentUser)
                    };
                } else
                {
                    return new GenericResponse<string>
                    {
                        Code = 401,
                        IsSuccess = false,
                        Message = "Your password is wrong!",
                        Result = null
                    };
                }
            } else
            {
                return new GenericResponse<string>
                {
                    Code = 401,
                    IsSuccess = false,
                    Message = "Your username is wrong!",
                    Result = null
                };
            }
        }

        public async Task<GenericResponse> Register(UserRegister user)
        {
            if(await UserExist(user.LoginName, user.Email))
            {
                return GenericResponse.Failed("User already exists!");
            } else
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newUser = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Gender = user.Gender,
                    Role = Role.User,
                    AccountStatus = AccountStatus.Active,
                    PhoneNumber = user.PhoneNumber,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ProfileImages = user.ProfileImages,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    LoginName = user.LoginName
                };
                _dbContext.Users.Add(newUser);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return GenericResponse.Success("Registered the new account!");
                } catch (Exception ex)
                {
                    return GenericResponse.Failed($"Error when registering new account: {ex.Message}");
                }
            }
        }

        public async Task<bool> UserExist(string loginName, string email)
        {
            if(
                await _dbContext.Users.AnyAsync(u => u.LoginName.ToLower().Equals(loginName.ToLower()))
                ||
                await _dbContext.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()))
                )
            {
                return true;
            }
            return false;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateUserToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,  user.Id.ToString()),
                new Claim(ClaimTypes.Name,  user.LoginName),
                new Claim(ClaimTypes.Email,  user.Email),
                new Claim(ClaimTypes.DateOfBirth,  user.DateOfBirth.ToString()),
                new Claim(ClaimTypes.Role,  user.Role.ToString()),
                new Claim(ClaimTypes.Gender,  user.Gender.ToString()),
                new Claim(ClaimTypes.GivenName,  user.UserName.ToString()),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<GenericResponse> ChangePassword(UserChangePW user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);
            if (VerifyPasswordHash(user.OldPassword, currentUser.PasswordHash, currentUser.PasswordSalt))
            {
                CreatePasswordHash(user.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                currentUser.PasswordHash = passwordHash;
                currentUser.PasswordSalt = passwordSalt;
                _dbContext.Users.Update(currentUser);
                await _dbContext.SaveChangesAsync();
                return GenericResponse.Success("Changed your password");
            } else
            {
                return GenericResponse.Failed("Your old password did not match");
            }
        }
    }
}
