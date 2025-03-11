using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
    public class ApplDbContext : DbContext
    {
        public ApplDbContext(DbContextOptions<ApplDbContext> options) : base(options)
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
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


    }

}

