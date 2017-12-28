using Microsoft.EntityFrameworkCore;

namespace NetCoreTests.EntityFrameworkCore.Data
{
    public class TestContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Children)
                .WithOne();

            modelBuilder.Entity<Category>()
                .Metadata
                .FindNavigation(nameof(Category.Children))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(c => c.Category)
                .WithMany();

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Categories)
                .WithOne(p => p.Product);

            modelBuilder.Entity<Product>()
                .Metadata
                .FindNavigation(nameof(Product.Categories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<Product>()
                .Metadata
                .FindNavigation(nameof(Product.Categories))
                .SetField("_productCategories");

            base.OnModelCreating(modelBuilder);
        }
    }
}
