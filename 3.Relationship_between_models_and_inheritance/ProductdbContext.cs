using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _3.Relationship_between_models_and_inheritance;

public partial class ProductdbContext : DbContext
{
    public ProductdbContext()
    {
        
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Word> Words { get; set; } = null!;
    public DbSet<KeyParams> KeyParams { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=199629wetprp");
    
}
