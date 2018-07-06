using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCartASP.Data;
using ShoppingCartASP.Models;

namespace ShoppingCartASP.Services
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public List<Order> OrdersList(string Id)
        {
            return _dbContext.Orders.Where(order => order.ApplicationUserId == Id).ToList();
        }
    }
}
