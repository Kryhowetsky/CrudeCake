using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeCrude.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

    }
}
