using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class addImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMainImage = table.Column<bool>(type: "bit", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsMainImage", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("920430e3-1298-4de3-890b-b383b233d5da"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" },
                    { new Guid("bcdc5ec2-e328-4bfd-9bbf-e9f1b67f0e91"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" },
                    { new Guid("ea9cfd4a-2537-46cf-b9d6-84c77672d741"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"),
                column: "ImageURL",
                value: "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"),
                column: "ImageURL",
                value: "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"),
                column: "ImageURL",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU");
        }
    }
}
