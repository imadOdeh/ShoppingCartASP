using ShoppingCartASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        List<Order> OrdersList(string Id);
    }
}
