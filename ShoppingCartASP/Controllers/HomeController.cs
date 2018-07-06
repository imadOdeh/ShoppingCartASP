using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartASP.Models;
using ShoppingCartASP.Services;
using ShoppingCartASP.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCartASP.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            List<Product> Products = _productService.Products();
            shoppingCart.products = Products.ToArray();
            var Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            if (Cart == null)
                shoppingCart.Quantities = new int[Products.Count];
            else
                shoppingCart.Quantities = Cart.Quantities;
            return View(shoppingCart);
        }

        [HttpPost]
        public IActionResult Index(ShoppingCart shoppingCart)
        {
            var Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            if (Cart == null)
            {
                for (int i = 0; i < shoppingCart.products.Length; i++)
                {
                    if (shoppingCart.Quantities[i] != 0)
                        shoppingCart.products[i] = _productService.GetProduct(shoppingCart.products[i].Id);
                }
                HttpContext.Session.SetObjectAsJson("ShoppingCart", shoppingCart);
            }
            else
            {
                for (int i = 0; i < shoppingCart.Quantities.Length; i++)
                    if (Cart.Quantities[i] <shoppingCart.Quantities[i])
                    {
                        Cart.Quantities[i] += shoppingCart.Quantities[i];
                        Cart.products[i] = _productService.GetProduct(shoppingCart.products[i].Id);
                    }
                HttpContext.Session.SetObjectAsJson("ShoppingCart", Cart);
            }
            return Redirect("Home/Cart");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Cart()
        {
            ShoppingCart shoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            return View(shoppingCart);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
