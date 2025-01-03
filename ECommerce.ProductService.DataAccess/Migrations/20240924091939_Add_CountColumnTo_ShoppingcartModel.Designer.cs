﻿// <auto-generated />
using System;
using ECommerce.ProductService.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.ProductService.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240924091939_Add_CountColumnTo_ShoppingcartModel")]
    partial class Add_CountColumnTo_ShoppingcartModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5217),
                            DisplayOrder = 1,
                            IsActive = true,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5237),
                            DisplayOrder = 2,
                            IsActive = true,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5238),
                            DisplayOrder = 3,
                            IsActive = true,
                            Name = "Furniture"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5239),
                            DisplayOrder = 4,
                            IsActive = true,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5240),
                            DisplayOrder = 5,
                            IsActive = true,
                            Name = "Toys and Hobbies"
                        });
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DiscountedPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SWD9999001",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5393),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 80.0,
                            IsActive = true,
                            Name = "WaterProof Bluetooth Smart Watch",
                            Price = 90.0
                        },
                        new
                        {
                            Id = 2,
                            Code = "CAW777777701",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5395),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 20.0,
                            IsActive = true,
                            Name = "Best Seller Drifit Shorts Unisex for Men",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 3,
                            Code = "RITO5555501",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5397),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 40.0,
                            IsActive = true,
                            Name = "Foldable Shoe Rack",
                            Price = 50.0
                        },
                        new
                        {
                            Id = 4,
                            Code = "WS3333333301",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5399),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 50.0,
                            IsActive = true,
                            Name = "Spicy Noodles",
                            Price = 65.0
                        },
                        new
                        {
                            Id = 5,
                            Code = "SOTJ1111111101",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5400),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 20.0,
                            IsActive = true,
                            Name = "Water Gun",
                            Price = 27.0
                        },
                        new
                        {
                            Id = 6,
                            Code = "FOT000000001",
                            CreateDate = new DateTime(2024, 9, 24, 17, 19, 39, 39, DateTimeKind.Local).AddTicks(5401),
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            DiscountedPrice = 20.0,
                            IsActive = true,
                            Name = "Wireless Headphones",
                            Price = 23.0
                        });
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ShoppingCartModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Shoppingcarts");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductCategoryModel", b =>
                {
                    b.HasOne("ECommerce.ProductService.Models.Models.CategoryModel", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.ProductService.Models.Models.ProductModel", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductImageModel", b =>
                {
                    b.HasOne("ECommerce.ProductService.Models.Models.ProductModel", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ShoppingCartModel", b =>
                {
                    b.HasOne("ECommerce.ProductService.Models.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.ProductService.Models.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.CategoryModel", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ECommerce.ProductService.Models.Models.ProductModel", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
