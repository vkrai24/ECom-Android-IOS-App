using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Models;

namespace ECommerceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configure Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.OriginalPrice)
                .HasPrecision(18, 2);

            // Configure Order
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            // Configure OrderItem
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Total)
                .HasPrecision(18, 2);

            // Configure Payment
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Bluetooth Headphones",
                    Description = "Premium wireless headphones with noise cancellation and 30-hour battery life.",
                    Price = 79.99m,
                    OriginalPrice = 99.99m,
                    Category = "Electronics",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 50,
                    Rating = 4.5m,
                    ReviewCount = 128
                },
                new Product
                {
                    Id = 2,
                    Name = "Smart Fitness Watch",
                    Description = "Track your fitness goals with this advanced smartwatch featuring heart rate monitoring.",
                    Price = 129.99m,
                    Category = "Electronics",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 30,
                    Rating = 4.7m,
                    ReviewCount = 256
                },
                new Product
                {
                    Id = 3,
                    Name = "Premium Leather Wallet",
                    Description = "Handcrafted genuine leather wallet with RFID protection.",
                    Price = 49.99m,
                    OriginalPrice = 69.99m,
                    Category = "Fashion",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 100,
                    Rating = 4.3m,
                    ReviewCount = 89
                },
                new Product
                {
                    Id = 4,
                    Name = "Portable Power Bank",
                    Description = "20000mAh high-capacity power bank with fast charging support.",
                    Price = 34.99m,
                    Category = "Electronics",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 75,
                    Rating = 4.6m,
                    ReviewCount = 312
                },
                new Product
                {
                    Id = 5,
                    Name = "Yoga Mat Pro",
                    Description = "Extra thick exercise yoga mat with carrying strap.",
                    Price = 29.99m,
                    Category = "Sports",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 60,
                    Rating = 4.8m,
                    ReviewCount = 167
                },
                new Product
                {
                    Id = 6,
                    Name = "Coffee Maker Deluxe",
                    Description = "Programmable coffee maker with thermal carafe.",
                    Price = 89.99m,
                    Category = "Home & Garden",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 25,
                    Rating = 4.4m,
                    ReviewCount = 94
                },
                new Product
                {
                    Id = 7,
                    Name = "Running Shoes Elite",
                    Description = "Professional running shoes with advanced cushioning technology.",
                    Price = 119.99m,
                    OriginalPrice = 149.99m,
                    Category = "Sports",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 45,
                    Rating = 4.7m,
                    ReviewCount = 203
                },
                new Product
                {
                    Id = 8,
                    Name = "Desk Lamp LED",
                    Description = "Adjustable LED desk lamp with USB charging port.",
                    Price = 39.99m,
                    Category = "Home & Garden",
                    ImageUrl = "https://via.placeholder.com/400",
                    Stock = 80,
                    Rating = 4.5m,
                    ReviewCount = 145
                }
            );
        }
    }
}
