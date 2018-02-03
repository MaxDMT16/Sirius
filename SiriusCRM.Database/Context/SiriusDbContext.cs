using Microsoft.EntityFrameworkCore;
using SiriusCRM.Database.Entities;

namespace SiriusCRM.Database.Context
{
    public class SiriusDbContext : DbContext, ISiriusContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SiriusDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);
            
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .HasKey(category => category.Id);

            modelBuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);
        }
    }
}