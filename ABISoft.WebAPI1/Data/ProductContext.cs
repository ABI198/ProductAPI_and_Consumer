using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.WebAPI1.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[] {
                new(){ Id=1, Name="Elektronik"},
                new(){ Id=2, Name="Giyim"},
            });
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id=1, Name="Bilgisayar", CreateDate = DateTime.Now.AddDays(-3), Price=15000, Stock=300, CategoryId=1},
                new(){Id=2, Name="Telefon", CreateDate = DateTime.Now.AddDays(-30), Price=10000, Stock=500, CategoryId=1},
                new(){Id=3, Name="Klavye", CreateDate = DateTime.Now.AddDays(-60), Price=100, Stock=1000, CategoryId=1},
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
