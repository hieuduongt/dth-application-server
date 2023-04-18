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
    [Migration("20230418063300_addedNewSeedData")]
    partial class addedNewSeedData
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
                            CreatedDate = new DateTime(2023, 4, 18, 13, 33, 0, 414, DateTimeKind.Local).AddTicks(839),
                            DateOfBirth = new DateTime(1997, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mydarhieu1997@gmail.com",
                            Gender = 0,
                            LoginName = "mydarhieu97",
                            PasswordHash = new byte[] { 77, 72, 104, 69, 79, 68, 74, 69, 82, 107, 70, 68, 81, 84, 85, 50, 82, 85, 78, 70, 77, 84, 74, 71, 81, 106, 99, 119, 81, 84, 100, 69, 81, 84, 103, 120, 78, 84, 85, 51, 81, 107, 78, 69, 82, 84, 108, 70, 81, 122, 108, 71, 78, 84, 107, 51, 77, 106, 74, 71, 78, 68, 69, 48, 81, 48, 73, 52, 78, 85, 86, 67, 82, 107, 89, 48, 81, 107, 77, 51, 79, 68, 90, 71, 78, 106, 69, 53, 82, 84, 85, 119, 78, 122, 108, 70, 78, 84, 89, 53, 78, 85, 85, 121, 82, 106, 77, 52, 82, 68, 78, 66, 81, 48, 82, 70, 79, 84, 103, 49, 77, 106, 66, 71, 82, 84, 90, 71, 79, 68, 86, 70, 82, 68, 107, 48, 78, 122, 77, 48, 77, 68, 86, 67, 79, 84, 103, 53, 78, 106, 65, 49, 77, 69, 81, 53, 77, 106, 81, 52, 78, 69, 73, 52, 81, 84, 73, 120, 77, 107, 69, 53, 82, 103, 61, 61 },
                            PasswordSalt = new byte[] { 77, 72, 103, 51, 77, 68, 86, 66, 77, 106, 108, 71, 77, 84, 73, 53, 78, 106, 99, 49, 77, 85, 77, 51, 82, 68, 85, 51, 78, 68, 73, 49, 78, 122, 100, 66, 77, 106, 99, 122, 77, 106, 99, 122, 82, 69, 77, 119, 77, 69, 85, 48, 82, 85, 73, 50, 82, 69, 78, 70, 78, 106, 107, 122, 78, 107, 82, 66, 77, 106, 70, 69, 77, 84, 82, 69, 77, 48, 70, 70, 77, 48, 77, 53, 78, 106, 85, 120, 81, 106, 89, 120, 77, 48, 89, 53, 79, 84, 108, 71, 82, 106, 100, 67, 81, 122, 74, 69, 77, 122, 89, 120, 78, 84, 69, 48, 77, 84, 100, 68, 81, 106, 108, 69, 81, 106, 74, 69, 79, 84, 103, 53, 78, 106, 73, 53, 82, 84, 86, 69, 78, 68, 66, 66, 79, 84, 85, 120, 81, 106, 104, 66, 77, 84, 103, 120, 79, 68, 103, 49, 78, 68, 81, 50, 77, 122, 104, 70, 78, 122, 89, 121, 79, 68, 78, 68, 77, 107, 89, 49, 81, 122, 90, 69, 79, 84, 99, 122, 78, 106, 73, 119, 77, 69, 74, 70, 81, 48, 77, 53, 82, 85, 77, 120, 82, 107, 85, 120, 81, 85, 81, 122, 77, 48, 85, 49, 77, 69, 82, 68, 81, 122, 85, 121, 82, 107, 70, 66, 78, 107, 70, 66, 82, 107, 82, 71, 77, 107, 73, 50, 78, 122, 73, 53, 77, 107, 82, 67, 79, 84, 65, 120, 78, 69, 89, 50, 77, 68, 77, 50, 81, 84, 85, 52, 82, 85, 73, 53, 78, 107, 85, 48, 77, 107, 85, 48, 82, 106, 69, 48, 77, 106, 81, 49, 81, 85, 82, 66, 78, 106, 81, 120, 77, 48, 86, 70, 79, 69, 77, 119, 78, 48, 81, 50, 81, 106, 73, 121, 77, 68, 81, 49, 77, 106, 65, 53, 82, 84, 85, 53, 77, 69, 86, 70, 79, 68, 77, 53, 79, 69, 85, 51, 78, 68, 73, 119, 79, 84, 69, 51, 79, 68, 100, 66 },
                            PhoneNumber = "0396346126",
                            Role = 0,
                            UpdatedDate = new DateTime(2023, 4, 18, 13, 33, 0, 414, DateTimeKind.Local).AddTicks(1007),
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
