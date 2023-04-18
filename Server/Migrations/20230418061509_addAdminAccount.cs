using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTHApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class addAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountStatus", "Address", "CreatedDate", "DateOfBirth", "Email", "Gender", "LoginName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("5f735207-fb9d-4bf9-a2e4-c17f20d96da2"), 0, "Cầu Giấy, Hà Nội", new DateTime(2023, 4, 18, 13, 15, 9, 812, DateTimeKind.Local).AddTicks(90), new DateTime(1997, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "mydarhieu1997@gmail.com", 0, "mydarhieu97", new byte[] { 48, 120, 68, 56, 50, 68, 70, 65, 67, 65, 53, 54, 69, 67, 69, 49, 50, 70, 66, 55, 48, 65, 55, 68, 65, 56, 49, 53, 53, 55, 66, 67, 68, 69, 57, 69, 67, 57, 70, 53, 57, 55, 50, 50, 70, 52, 49, 52, 67, 66, 56, 53, 69, 66, 70, 70, 52, 66, 67, 55, 56, 54, 70, 54, 49, 57, 69, 53, 48, 55, 57, 69, 53, 54, 57, 53, 69, 50, 70, 51, 56, 68, 51, 65, 67, 68, 69, 57, 56, 53, 50, 48, 70, 69, 54, 70, 56, 53, 69, 68, 57, 52, 55, 51, 52, 48, 53, 66, 57, 56, 57, 54, 48, 53, 48, 68, 57, 50, 52, 56, 52, 66, 56, 65, 50, 49, 50, 65, 57, 70 }, new byte[] { 48, 120, 55, 48, 53, 65, 50, 57, 70, 49, 50, 57, 54, 55, 53, 49, 67, 55, 68, 53, 55, 52, 50, 53, 55, 55, 65, 50, 55, 51, 50, 55, 51, 68, 67, 48, 48, 69, 52, 69, 66, 54, 68, 67, 69, 54, 57, 51, 54, 68, 65, 50, 49, 68, 49, 52, 68, 51, 65, 69, 51, 67, 57, 54, 53, 49, 66, 54, 49, 51, 70, 57, 57, 57, 70, 70, 55, 66, 67, 50, 68, 51, 54, 49, 53, 49, 52, 49, 55, 67, 66, 57, 68, 66, 50, 68, 57, 56, 57, 54, 50, 57, 69, 53, 68, 52, 48, 65, 57, 53, 49, 66, 56, 65, 49, 56, 49, 56, 56, 53, 52, 52, 54, 51, 56, 69, 55, 54, 50, 56, 51, 67, 50, 70, 53, 67, 54, 68, 57, 55, 51, 54, 50, 48, 48, 66, 69, 67, 67, 57, 69, 67, 49, 70, 69, 49, 65, 68, 51, 51, 69, 53, 48, 68, 67, 67, 53, 50, 70, 65, 65, 54, 65, 65, 70, 68, 70, 50, 66, 54, 55, 50, 57, 50, 68, 66, 57, 48, 49, 52, 70, 54, 48, 51, 54, 65, 53, 56, 69, 66, 57, 54, 69, 52, 50, 69, 52, 70, 49, 52, 50, 52, 53, 65, 68, 65, 54, 52, 49, 51, 69, 69, 56, 67, 48, 55, 68, 54, 66, 50, 50, 48, 52, 53, 50, 48, 57, 69, 53, 57, 48, 69, 69, 56, 51, 57, 56, 69, 55, 52, 50, 48, 57, 49, 55, 56, 55, 65 }, "0396346126", 0, new DateTime(2023, 4, 18, 13, 15, 9, 812, DateTimeKind.Local).AddTicks(232), "Hieu Duong" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f735207-fb9d-4bf9-a2e4-c17f20d96da2"));
        }
    }
}
