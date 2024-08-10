using crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.Context
{
    internal class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=products;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Price).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");
                entity.Property(o => o.Address).IsRequired().HasMaxLength(255);
                entity.Property(o => o.CreatedAt).HasColumnName("created_at");
            });


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
