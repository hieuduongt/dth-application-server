using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class addOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("920430e3-1298-4de3-890b-b383b233d5da"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bcdc5ec2-e328-4bfd-9bbf-e9f1b67f0e91"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ea9cfd4a-2537-46cf-b9d6-84c77672d741"));

            migrationBuilder.AddColumn<bool>(
                name: "OutOfStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
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
                    { new Guid("2f98d4cb-0351-4baa-8caf-aea53e4dc101"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" },
                    { new Guid("33b5a225-bdf7-439d-a5b0-fb992f01593e"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" },
                    { new Guid("f1065fdc-d0c4-4ceb-99ef-b8d787a9b395"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"),
                columns: new[] { "OutOfStock", "Quantity" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"),
                columns: new[] { "OutOfStock", "Quantity" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"),
                columns: new[] { "OutOfStock", "Quantity" },
                values: new object[] { false, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

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

            migrationBuilder.DropColumn(
                name: "OutOfStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsMainImage", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("920430e3-1298-4de3-890b-b383b233d5da"), true, new Guid("2d343e0f-53ed-440f-b1ac-6bbfd310fb4e"), "https://laptop88.vn/media/product/6927_dsc08733__6_.jpg" },
                    { new Guid("bcdc5ec2-e328-4bfd-9bbf-e9f1b67f0e91"), true, new Guid("879afcae-994a-4d68-a9da-2e8cb49c5c9f"), "https://didongviet.vn/pub/media/catalog/product//s/a/samsung-galaxy-s23-ultra-5g-mau-xanh.png" },
                    { new Guid("ea9cfd4a-2537-46cf-b9d6-84c77672d741"), true, new Guid("d7873eda-0f41-4dda-9514-6df017559dbe"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhQl7FNuj_p9dROneitk5A3z9gafp65SD2Iw&usqp=CAU" }
                });
        }
    }
}
