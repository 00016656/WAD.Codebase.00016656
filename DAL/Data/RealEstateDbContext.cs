using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD.Codebase._00016656.Models;

namespace WAD.Codebase._00016656.Data
{
    public class RealEstateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Seeding
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Aliyev Anvar", Email = "anvar@example.com", PasswordHash = "hashed_password_1", PhoneNumber = "+998901234567", Role = "Agent" },
                new User { Id = 2, FullName = "Bekova Gulnara", Email = "gulnara@example.com", PasswordHash = "hashed_password_2", PhoneNumber = "+998903456789", Role = "Seller" },
                new User { Id = 3, FullName = "Karimov Jamshid", Email = "jamshid@example.com", PasswordHash = "hashed_password_3", PhoneNumber = "+998902345678", Role = "Buyer" }
            );

            // Property Seeding
            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Title = "Luxury Apartment in Tashkent City",
                    Description = "A modern 3-bedroom apartment located in Tashkent City.",
                    Address = "Amir Temur Avenue, Tashkent",
                    Price = 150000,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    SquareFeet = 1200,
                    PropertyType = "Apartment",
                    ListedDate = DateTime.Now,
                    UserId = 1
                },
                new Property
                {
                    Id = 2,
                    Title = "Cozy House in Samarkand",
                    Description = "A spacious family house with a garden in Samarkand.",
                    Address = "Bukhara Street, Samarkand",
                    Price = 100000,
                    Bedrooms = 4,
                    Bathrooms = 3,
                    SquareFeet = 2000,
                    PropertyType = "House",
                    ListedDate = DateTime.Now,
                    UserId = 2
                },
                new Property
                {
                    Id = 3,
                    Title = "Commercial Space in Andijan",
                    Description = "Prime location for a business in Andijan.",
                    Address = "Navoi Avenue, Andijan",
                    Price = 250000,
                    Bedrooms = 0,
                    Bathrooms = 2,
                    SquareFeet = 3000,
                    PropertyType = "Commercial",
                    ListedDate = DateTime.Now,
                    UserId = 1
                }
            );
        }
    }
}
