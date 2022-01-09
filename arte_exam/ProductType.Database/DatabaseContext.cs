using System;
using Microsoft.EntityFrameworkCore;
using ProductType.Database.Models;

namespace ProductType.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=ProductRoles;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Product> Products { set; get; }
    }
}
