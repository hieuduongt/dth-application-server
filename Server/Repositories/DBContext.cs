using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared.Common
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = new Guid("79675121-4854-4266-9438-8b6e19a99c9b"),
                    CategoryName = "Mobile Phones",
                    Url = "mobile-phones"
                },
                new Category
                {
                    Id = new Guid("bb3ebf6f-df7c-4298-8bc4-673093e41fb1"),
                    CategoryName = "Laptops",
                    Url = "laptops"
                },
                new Category
                {
                    Id = new Guid("5ce4386e-ea5f-4548-a3a0-cb7ce81fa809"),
                    CategoryName = "Books",
                    Url = "books"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"),
                    ProductName = "Samsung Galaxy S23 Ultra",
                    Price = 31990000,
                    Description = "Samsung Galaxy S23 Ultra là điện thoại cao cấp của hãng điện thoại Samsung được ra mắt vào đầu năm 2023. Điện thoại Samsung S23 series mới này sở hữu camera độ phân giải 200MP ấn tượng cùng một khung viền vuông vức sang trọng. Cấu hình máy cũng là một điểm nổi bật với con chip Snapdragon 8 Gen 2 mạnh mẽ, bộ nhớ RAM 8GB mang lại hiệu suất xử lý vượt trội.",
                    CategoryId = new Guid("79675121-4854-4266-9438-8b6e19a99c9b")
                },
                new Product
                {
                    Id = new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"),
                    ProductName = "iPhone 14 Pro Max",
                    Price = 28390000,
                    Description = "A magical new way to interact with iPhone. A vital new safety feature designed to save lives. An innovative 48MP camera for mind-blowing detail. All powered by the ultimate smartphone chip.",
                    CategoryId = new Guid("79675121-4854-4266-9438-8b6e19a99c9b")
                },
                new Product
                {
                    Id = new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"),
                    ProductName = "Laptop Acer Nitro 5 Tiger 2022 AN515-58-74B7",
                    Price = 26990000,
                    Description = "Chiếc laptop gaming Acer Nitro 5 i7 12700H là mẫu máy tính xách tay, laptop có cấu hình cao nhất nằm trong siêu phẩm Acer Nitro 5 mới ra mắt đến từ thương hiệu laptop Acer nổi tiếng. Mẫu laptop Acer Core i7 này đã được thay bằng một diện mạo hoàn toàn mới từ thiết kế cho tới cấu hình, sẽ cho các game thủ có được trải nghiệm chiến game cực đã; đồng thời máy còn đáp ứng tốt các công việc thiết kế đồ họa 3D phức tạp của người dùng khi là chiếc Acer Nitro duy nhất hiện nay được trang bị màn hình chuẩn màu. Để tìm hiểu chi tiết hơn về sản phẩm, các bạn hãy tham khảo ngay nội dung dưới đây nhé!",
                    CategoryId = new Guid("bb3ebf6f-df7c-4298-8bc4-673093e41fb1")
                }
            );

            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ProductId = new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"),
                    URL = "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png",
                    Id = Guid.NewGuid(),
                    IsMainImage = true
                },
                new Image
                {
                    ProductId = new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"),
                    URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU",
                    Id = Guid.NewGuid(),
                    IsMainImage = true
                },
                new Image
                {
                    ProductId = new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"),
                    URL = "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg",
                    Id = Guid.NewGuid(),
                    IsMainImage = true
                }
            );
        } 

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
