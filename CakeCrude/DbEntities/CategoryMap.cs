using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeCrude.DbEntities
{
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.Property(t => t.Name).IsRequired();

            entityBuilder.HasMany(t => t.Products)
                         .WithOne(t => t.Category)
                         .HasForeignKey(t => t.CategoryId);
        }
    }
}