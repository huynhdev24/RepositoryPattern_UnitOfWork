using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {
        }

        public List<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return base.Find(predicate).ToList();
        }

        public Order Update(Order order)
        {
            return base.Update(order);
        }
    }
}
