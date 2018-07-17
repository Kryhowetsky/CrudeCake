using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeCrude.DbEntities
{
    public class CakeCrudContext : DbContext
    {
        public CakeCrudContext(DbContextOptions<CakeCrudContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
            new CategoryMap(modelBuilder.Entity<Category>());
        }
    }
}
