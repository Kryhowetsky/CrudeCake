using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeCrude.DbEntities
{
    public class OrderCakeMap
    {
        public OrderCakeMap(EntityTypeBuilder<OrderCake> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Surname).IsRequired();
            entityBuilder.Property(t => t.Phone).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Comment);
            entityBuilder.Property(t => t.Date);
        }
    }
}
