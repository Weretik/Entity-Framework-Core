using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2.Fluent_API_Data_Annotations_migration;
/*
 * Завдання 3*
 * Продовжуйте завданя 2 (цього уроку).
 * Спробуйте налаштувати все без застосування DataAnnotations.
 * Частіше Ви будете зустрічати налаштування через Fluent API (Приклад), тому варто вміти реалізовувати двома способами.
*/

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
    public virtual DbSet<Error> Errors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=199629wetprp");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Error>();
        modelBuilder.ApplyConfiguration(new ProductConfiguretion());
    }

}

public class ProductConfiguretion : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => new { p.Id, p.AlterId });
        builder.Property(p => p.Id).HasColumnName("Product_id");
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Cost).HasColumnType("money");
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.ManufactureDate).HasColumnType("date");
    }
} 


