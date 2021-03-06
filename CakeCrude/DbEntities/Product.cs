﻿using System;

namespace CakeCrude.DbEntities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}