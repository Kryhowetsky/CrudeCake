using CakeCrude.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeCrude.Repository
{
    public class OrderCakeRepository
    {
        private readonly DbSet<OrderCake> _dbSet;
        private readonly CakeCrudContext _context;

        public OrderCakeRepository(CakeCrudContext context)
        {
            _context = context;
            _dbSet = context.Set<OrderCake>();
        }

        public List<OrderCake> GetAll()
        {
            var allOrderCakes = _dbSet.ToList();
            return allOrderCakes;
        }

        public void Add(OrderCake order)
        {
            _dbSet.Add(order);
            _context.SaveChanges();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}