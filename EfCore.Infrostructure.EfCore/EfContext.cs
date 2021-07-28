  using System;
using EfCore.Domain.ProductAgg;
  using EfCore.Domain.ProductCategoryAgg;
  using EFCore.Infrastructure.EFCore.Mapping;
  using EfCore.Infrostructure.EfCore.Mapping;
  using Microsoft.EntityFrameworkCore;

  namespace EfCore.Infrastructure.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EfContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());

            //select all of the type mapping in this assembly
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
