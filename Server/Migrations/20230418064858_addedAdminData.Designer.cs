﻿// <auto-generated />
using System;
using DTHApplication.Shared.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTHApplication.Server.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230418064858_addedAdminData")]
    partial class addedAdminData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTHApplication.Shared.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DTHApplication.Shared.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMainImage")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DTHApplication.Shared.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfReceipt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DTHApplication.Shared.OrderProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("DTHApplication.Shared.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OutOfStock")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DTHApplication.Shared.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f735207-fb9d-4bf9-a2e4-c17f20d96da2"),
                            AccountStatus = 0,
                            Address = "Cầu Giấy, Hà Nội",
                            CreatedDate = new DateTime(2023, 4, 18, 13, 48, 58, 611, DateTimeKind.Local).AddTicks(2238),
                            DateOfBirth = new DateTime(1997, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mydarhieu1997@gmail.com",
                            Gender = 0,
                            LoginName = "mydarhieu97",
                            PasswordHash = new byte[] { 228, 10, 130, 96, 100, 213, 48, 124, 203, 224, 29, 164, 162, 213, 209, 94, 160, 114, 29, 57, 66, 204, 24, 146, 75, 76, 146, 9, 47, 58, 181, 144, 8, 172, 29, 46, 111, 101, 84, 80, 93, 216, 195, 248, 105, 157, 109, 215, 5, 157, 24, 133, 231, 70, 100, 199, 244, 21, 246, 102, 255, 102, 228, 132 },
                            PasswordSalt = new byte[] { 195, 145, 178, 3, 8, 49, 255, 137, 189, 191, 193, 40, 89, 46, 58, 57, 241, 63, 114, 85, 21, 152, 240, 211, 116, 43, 21, 22, 251, 218, 150, 215, 247, 145, 153, 64, 71, 251, 134, 215, 153, 64, 103, 108, 175, 67, 200, 192, 7, 241, 114, 188, 43, 98, 167, 186, 14, 7, 186, 117, 234, 211, 93, 75, 254, 37, 226, 229, 7, 39, 133, 192, 140, 127, 54, 28, 85, 161, 234, 70, 169, 188, 61, 111, 209, 11, 26, 88, 28, 140, 202, 80, 217, 30, 168, 95, 135, 74, 74, 126, 254, 140, 171, 66, 161, 76, 202, 42, 43, 23, 16, 66, 81, 234, 78, 135, 31, 84, 164, 82, 185, 196, 96, 153, 229, 200, 178, 120 },
                            PhoneNumber = "0396346126",
                            Role = 0,
                            UpdatedDate = new DateTime(2023, 4, 18, 13, 48, 58, 611, DateTimeKind.Local).AddTicks(2352),
                            UserName = "Hieu Duong"
                        });
                });

            modelBuilder.Entity("DTHApplication.Shared.Image", b =>
                {
                    b.HasOne("DTHApplication.Shared.Product", "Product")
                        .WithMany("ImageURLs")
                        .HasForeignKey("ProductId");

                    b.HasOne("DTHApplication.Shared.User", "User")
                        .WithMany("ProfileImages")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DTHApplication.Shared.OrderProduct", b =>
                {
                    b.HasOne("DTHApplication.Shared.Order", "Order")
                        .WithMany("OrderProduct")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTHApplication.Shared.Product", "Product")
                        .WithMany("OrderProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DTHApplication.Shared.Product", b =>
                {
                    b.HasOne("DTHApplication.Shared.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DTHApplication.Shared.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DTHApplication.Shared.Order", b =>
                {
                    b.Navigation("OrderProduct");
                });

            modelBuilder.Entity("DTHApplication.Shared.Product", b =>
                {
                    b.Navigation("ImageURLs");

                    b.Navigation("OrderProduct");
                });

            modelBuilder.Entity("DTHApplication.Shared.User", b =>
                {
                    b.Navigation("ProfileImages");
                });
#pragma warning restore 612, 618
        }
    }
}
