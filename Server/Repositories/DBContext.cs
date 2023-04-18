using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTHApplication.Server;

namespace DTHApplication.Shared.Common
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new AdminUser().InitialAdminUser()
            );
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.ProductId, op.OrderId });
            modelBuilder.Entity<OrderProduct>().HasOne<Product>(op => op.Product).WithMany(p => p.OrderProduct).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<OrderProduct>().HasOne<Order>(op => op.Order).WithMany(o => o.OrderProduct).HasForeignKey(o => o.OrderId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
