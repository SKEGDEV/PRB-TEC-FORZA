using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Product => Set<Product>();
        public DbSet<ProductType> ProductType => Set<ProductType>();
        public DbSet<ProductStatus> ProductStatus => Set<ProductStatus>();
        public DbSet<Invoice> Invoice => Set<Invoice>();
        public DbSet<InvoiceProduct> InvoiceProduct => Set<InvoiceProduct>();
       
    }
}
