using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class removeOrderQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Quantity",
                table: "Orders");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
