using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeCrude.Models
{
    public class OrderCakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
