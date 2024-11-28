﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAD.Codebase._00016656.Data;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    partial class RealEstateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WAD.Codebase._00016656.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ListedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SquareFeet")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Amir Temur Avenue, Tashkent",
                            Bathrooms = 2,
                            Bedrooms = 3,
                            Description = "A modern 3-bedroom apartment located in Tashkent City.",
                            ListedDate = new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6123),
                            Price = 150000m,
                            PropertyType = "Apartment",
                            SquareFeet = 1200.0,
                            Title = "Luxury Apartment in Tashkent City",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bukhara Street, Samarkand",
                            Bathrooms = 3,
                            Bedrooms = 4,
                            Description = "A spacious family house with a garden in Samarkand.",
                            ListedDate = new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6137),
                            Price = 100000m,
                            PropertyType = "House",
                            SquareFeet = 2000.0,
                            Title = "Cozy House in Samarkand",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Navoi Avenue, Andijan",
                            Bathrooms = 2,
                            Bedrooms = 0,
                            Description = "Prime location for a business in Andijan.",
                            ListedDate = new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6139),
                            Price = 250000m,
                            PropertyType = "Commercial",
                            SquareFeet = 3000.0,
                            Title = "Commercial Space in Andijan",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WAD.Codebase._00016656.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "anvar@example.com",
                            FullName = "Aliyev Anvar",
                            PasswordHash = "hashed_password_1",
                            PhoneNumber = "+998901234567",
                            Role = "Agent"
                        },
                        new
                        {
                            Id = 2,
                            Email = "gulnara@example.com",
                            FullName = "Bekova Gulnara",
                            PasswordHash = "hashed_password_2",
                            PhoneNumber = "+998903456789",
                            Role = "Seller"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jamshid@example.com",
                            FullName = "Karimov Jamshid",
                            PasswordHash = "hashed_password_3",
                            PhoneNumber = "+998902345678",
                            Role = "Buyer"
                        });
                });

            modelBuilder.Entity("WAD.Codebase._00016656.Models.Property", b =>
                {
                    b.HasOne("WAD.Codebase._00016656.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}