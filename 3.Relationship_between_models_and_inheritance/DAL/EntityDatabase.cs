using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EntityDatabase : DbContext
    {
        public EntityDatabase(DbContextOptions<EntityDatabase> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Word> Words { get; set; } = null!;
        public DbSet<KeyParams> KeyParams { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
    }
}