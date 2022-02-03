using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PaintEquipment.Models
    
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartRow>()
                .HasOne(p=>p.Product)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
