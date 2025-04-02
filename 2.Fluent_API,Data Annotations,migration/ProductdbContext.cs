using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2.Fluent_API_Data_Annotations_migration;

public partial class ProductdbContext : DbContext
{
    public ProductdbContext()
    {
    }

    public ProductdbContext(DbContextOptions<ProductdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=199629wetprp");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
    }

}
