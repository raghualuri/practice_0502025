// File: practice_0502025.Application/ApplicationDbContext.cs
// Or:   practice_0502025.Infrastructure.Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;
using practice_0502025.Entities; // Assuming your entity classes (Product, Category, Order, OrderItem) are in this namespace

namespace practice_0502025.Application // Or practice_0502025.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // --- DbSet Properties for Your Entities ---
        public DbSet<Product> Products { get; set; } = null!; // null! to indicate it will be initialized by EF Core
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Configure Relationships using Fluent API ---

            // Product and Category (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)           // A Product has one Category
                .WithMany(c => c.Products)         // A Category has many Products
                .HasForeignKey(p => p.CategoryId)  // The foreign key is CategoryId in Product
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Category if Products are linked to it

            // Order and OrderItem (One-to-Many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)            // An OrderItem belongs to one Order
                .WithMany(o => o.OrderItems)       // An Order has many OrderItems
                .HasForeignKey(oi => oi.OrderId)   // The foreign key is OrderId in OrderItem
                .OnDelete(DeleteBehavior.Cascade); // If an Order is deleted, its OrderItems are also deleted

            // OrderItem and Product (One-to-Many, where OrderItem is the 'many' side)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)          // An OrderItem references one Product
                .WithMany()                        // No direct navigation collection from Product back to OrderItems
                                                   // (If you need it, add ICollection<OrderItem> to Product entity)
                .HasForeignKey(oi => oi.ProductId) // The foreign key is ProductId in OrderItem
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Product if OrderItems are linked to it

            // --- Optional: Seed Data for Initial Population ---
            // This data will be added to your database when you run 'dotnet ef database update'
            // and apply this migration.

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Apparel" },
                new Category { Id = 4, Name = "Home Goods" }
            );

            // Seed Products (ensure CategoryIds match the seeded categories)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 101, Name = "Laptop Pro X", Price = 1200.00m, CategoryId = 1, Stock = 50 },
                new Product { Id = 102, Name = "Wireless Mouse", Price = 25.00m, CategoryId = 1, Stock = 200 },
                new Product { Id = 103, Name = "Mechanical Keyboard", Price = 80.00m, CategoryId = 1, Stock = 100 },
                new Product { Id = 104, Name = "The Hitchhiker's Guide to the Galaxy", Price = 15.99m, CategoryId = 2, Stock = 75 },
                new Product { Id = 105, Name = "1984 by George Orwell", Price = 12.50m, CategoryId = 2, Stock = 60 },
                new Product { Id = 106, Name = "Men's T-Shirt", Price = 20.00m, CategoryId = 3, Stock = 150 }
            );

            // Seed Orders
            // Note: If you add a Customer entity, you'd adjust CustomerId and potentially add Customer seed data.
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2025, 6, 15, 10, 30, 0, DateTimeKind.Utc), CustomerId = 1, TotalAmount = 1260.00m },
                new Order { Id = 2, OrderDate = new DateTime(2025, 6, 16, 14, 0, 0, DateTimeKind.Utc), CustomerId = 2, TotalAmount = 53.00m }
            );

            // Seed OrderItems
            // Ensure ProductIds and OrderIds match the seeded data above
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 101, Quantity = 1, UnitPrice = 1200.00m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 102, Quantity = 2, UnitPrice = 25.00m },
                new OrderItem { Id = 3, OrderId = 2, ProductId = 106, Quantity = 2, UnitPrice = 20.00m },
                new OrderItem { Id = 4, OrderId = 2, ProductId = 105, Quantity = 1, UnitPrice = 12.50m }
            );
        }
    }
}