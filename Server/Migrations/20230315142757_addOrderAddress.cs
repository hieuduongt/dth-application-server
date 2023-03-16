using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class addOrderAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2f98d4cb-0351-4baa-8caf-aea53e4dc101"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("33b5a225-bdf7-439d-a5b0-fb992f01593e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f1065fdc-d0c4-4ceb-99ef-b8d787a9b395"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsMainImage", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("14941c76-6535-44e5-9b9b-e28f74e2c52f"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" },
                    { new Guid("9adc2e02-23dc-4e5f-b36c-11aa7ea8b7bb"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" },
                    { new Guid("d9d5466a-aa6b-441d-a977-643d7dcead96"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("14941c76-6535-44e5-9b9b-e28f74e2c52f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9adc2e02-23dc-4e5f-b36c-11aa7ea8b7bb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d9d5466a-aa6b-441d-a977-643d7dcead96"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsMainImage", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("2f98d4cb-0351-4baa-8caf-aea53e4dc101"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" },
                    { new Guid("33b5a225-bdf7-439d-a5b0-fb992f01593e"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" },
                    { new Guid("f1065fdc-d0c4-4ceb-99ef-b8d787a9b395"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" }
                });
        }
    }
}
