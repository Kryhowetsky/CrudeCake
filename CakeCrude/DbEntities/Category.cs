using System.Collections.Generic;

namespace CakeCrude.DbEntities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
