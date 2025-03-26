using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // category-product (one-to-many)
             modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId);

            // customer-order (one-to-many)
            modelBuilder.Entity<Order>()
              .HasOne(o => o.Customer)
              .WithMany(c => c.Orders)
              .HasForeignKey(o => o.CustomerId);


            // many to many relationship Order-OrderItem-Product 

            // order-orderitem (one-to-many)

             modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // product-orderitem (one-to-many)

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);


            // AI Generated Seed Data


            // 1. Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic gadgets and devices" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and fashion items" },
                new Category { Id = 3, Name = "Books", Description = "A wide range of books" }
            );

            // 2. Seed Products (referencing Category IDs)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Laptop", Price = 1200.00m, Description = "High-performance laptop", Image = "laptop.jpg" },
                new Product { Id = 2, CategoryId = 1, Name = "Smartphone", Price = 800.00m, Description = "Latest smartphone model", Image = "smartphone.jpg" },
                new Product { Id = 3, CategoryId = 2, Name = "T-Shirt", Price = 25.00m, Description = "Cotton t-shirt", Image = "tshirt.jpg" },
                new Product { Id = 4, CategoryId = 2, Name = "Jeans", Price = 50.00m, Description = "Denim jeans", Image = "jeans.jpg" },
                new Product { Id = 5, CategoryId = 3, Name = "Fiction Novel", Price = 15.00m, Description = "Bestselling fiction novel", Image = "fiction_novel.jpg" },
                new Product { Id = 6, CategoryId = 3, Name = "Cookbook", Price = 20.00m, Description = "Delicious recipes cookbook", Image = "cookbook.jpg" }
            );

            // 3. Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "987-654-3210" }
            );

            // 4. Seed Orders (referencing Customer IDs)
            modelBuilder.Entity<Order>().HasData(
                 new Order { Id = 1, CustomerId = 1, OrderDate = new DateTime(2024, 01, 15, 10, 30, 00), TotalAmount = 1225.00m }, // Order from John Doe - January 15, 2024, 10:30 AM
                 new Order { Id = 2, CustomerId = 2, OrderDate = new DateTime(2024, 01, 19, 14, 00, 00), TotalAmount = 85.00m }   // Order from Jane Smith - January 19, 2024, 2:00 PM
             );

            // 5. Seed OrderItems (referencing Order IDs and Product IDs)
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 1200.00m }, 
                new OrderItem { Id = 2, OrderId = 1, ProductId = 3, Quantity = 1, Price = 25.00m },   
                new OrderItem { Id = 3, OrderId = 2, ProductId = 4, Quantity = 1, Price = 50.00m },   
                new OrderItem { Id = 4, OrderId = 2, ProductId = 5, Quantity = 2, Price = 15.00m }  
            );



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


    }

}

