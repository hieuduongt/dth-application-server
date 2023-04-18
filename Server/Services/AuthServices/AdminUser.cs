using DTHApplication.Server.Services.AuthServices;
using DTHApplication.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Server
{
    public class AdminUser
    {
        public User InitialAdminUser() {
            CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            return new User{
                Id = new Guid("5f735207-fb9d-4bf9-a2e4-c17f20d96da2"),
                LoginName = "mydarhieu97",
                Email = "mydarhieu1997@gmail.com",
                AccountStatus = AccountStatus.Active,
                Address = "Cầu Giấy, Hà Nội",
                CreatedDate = DateTime.Now,
                DateOfBirth = DateTime.Parse("1/19/1997"),
                Gender = Gender.Male,
                PhoneNumber = "0396346126",
                Role = Role.Admin,
                UpdatedDate = DateTime.Now,
                UserName = "Hieu Duong",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
