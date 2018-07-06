using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartASP.Extensions;
using ShoppingCartASP.Models;
using ShoppingCartASP.Services;

namespace ShoppingCartASP.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var shoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            Order order = new Order
            {
                Quantities = shoppingCart.Quantities,
                OrderDate = DateTime.Now,
                Products = new int [shoppingCart.Quantities.Length]
            };
            double sum=0;
            for(int i=0; i< shoppingCart.products.Length;i++)
            {
                order.Products[i] = shoppingCart.products[i].Id;
                sum = +shoppingCart.products[i].price*shoppingCart.Quantities[i];
            }
            order.TotalCost = sum;
            _orderService.CreateOrder(order);
            return View(order);
        }

        [HttpGet]
        public IActionResult ShowOrders(string userId)
        {
            List<Order> orders= _orderService.OrdersList(userId);
            return View(orders);
        }
    }
}