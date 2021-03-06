﻿using System;
using System.Collections.Generic;

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
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}