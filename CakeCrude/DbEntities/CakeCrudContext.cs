using Microsoft.EntityFrameworkCore;

namespace CakeCrude.DbEntities
{
    public class CakeCrudContext : DbContext
    {
        public CakeCrudContext(DbContextOptions<CakeCrudContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new OrderCakeMap(modelBuilder.Entity<OrderCake>());
            new FileMap(modelBuilder.Entity<File>());
        }
    }
}