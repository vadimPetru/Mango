using Mango.Services.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Mango.Services.ProductAPI.Extension
{
    public static class SeedDataExtension
    {
        public static void AddSeedDataProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 1225,
                Description = "Nice Good",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName = "Dinner"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Alexoid",
                Price = 75,
                Description = "Nice Good",
                ImageUrl = "https://placehold.co/602x402",
                CategoryName = "Dinner"

            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "GoldFish",
                Price = 45,
                Description = "Nice Good",
                ImageUrl = "https://placehold.co/601x401",
                CategoryName = "Launch"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Kesstel",
                Price = 25,
                Description = "Nice Good",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "Dinner"

            });
        } 
    }
}
