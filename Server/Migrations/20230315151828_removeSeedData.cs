using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class removeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ce4386e-ea5f-4548-a3a0-cb7ce81fa809"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("923b850c-1dcc-4c50-a162-0771f11d4702"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e33ed7d7-c864-4d0a-94d3-5d52a62eb128"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f386303f-195f-414f-a3b4-59d1a4ccd2f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("79675121-4854-4266-9438-8b6e19a99c9b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb3ebf6f-df7c-4298-8bc4-673093e41fb1"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Url" },
                values: new object[,]
                {
                    { new Guid("5ce4386e-ea5f-4548-a3a0-cb7ce81fa809"), "Books", "books" },
                    { new Guid("79675121-4854-4266-9438-8b6e19a99c9b"), "Mobile Phones", "mobile-phones" },
                    { new Guid("bb3ebf6f-df7c-4298-8bc4-673093e41fb1"), "Laptops", "laptops" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "OutOfStock", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), new Guid("bb3ebf6f-df7c-4298-8bc4-673093e41fb1"), "Chiếc laptop gaming Acer Nitro 5 i7 12700H là mẫu máy tính xách tay, laptop có cấu hình cao nhất nằm trong siêu phẩm Acer Nitro 5 mới ra mắt đến từ thương hiệu laptop Acer nổi tiếng. Mẫu laptop Acer Core i7 này đã được thay bằng một diện mạo hoàn toàn mới từ thiết kế cho tới cấu hình, sẽ cho các game thủ có được trải nghiệm chiến game cực đã; đồng thời máy còn đáp ứng tốt các công việc thiết kế đồ họa 3D phức tạp của người dùng khi là chiếc Acer Nitro duy nhất hiện nay được trang bị màn hình chuẩn màu. Để tìm hiểu chi tiết hơn về sản phẩm, các bạn hãy tham khảo ngay nội dung dưới đây nhé!", false, 26990000.0, "Laptop Acer Nitro 5 Tiger 2022 AN515-58-74B7", 0 },
                    { new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), new Guid("79675121-4854-4266-9438-8b6e19a99c9b"), "Samsung Galaxy S23 Ultra là điện thoại cao cấp của hãng điện thoại Samsung được ra mắt vào đầu năm 2023. Điện thoại Samsung S23 series mới này sở hữu camera độ phân giải 200MP ấn tượng cùng một khung viền vuông vức sang trọng. Cấu hình máy cũng là một điểm nổi bật với con chip Snapdragon 8 Gen 2 mạnh mẽ, bộ nhớ RAM 8GB mang lại hiệu suất xử lý vượt trội.", false, 31990000.0, "Samsung Galaxy S23 Ultra", 0 },
                    { new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), new Guid("79675121-4854-4266-9438-8b6e19a99c9b"), "A magical new way to interact with iPhone. A vital new safety feature designed to save lives. An innovative 48MP camera for mind-blowing detail. All powered by the ultimate smartphone chip.", false, 28390000.0, "iPhone 14 Pro Max", 0 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsMainImage", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("923b850c-1dcc-4c50-a162-0771f11d4702"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" },
                    { new Guid("e33ed7d7-c864-4d0a-94d3-5d52a62eb128"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" },
                    { new Guid("f386303f-195f-414f-a3b4-59d1a4ccd2f2"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" }
                });
        }
    }
}
