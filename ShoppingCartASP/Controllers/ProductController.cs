using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartASP.Models;
using ShoppingCartASP.Services;

namespace ShoppingCartASP.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IProductService productService
            , IHostingEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }
        public string Index()
        {
            return "Hello World";
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Product> Products = _productService.Products();
            foreach (var product in Products)
                product.Image = "/images/" + product.Image;
            return View(Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product,IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            Random random = new Random();
            if (file != null)
            {
                var imageName = random.Next() + file.FileName;
                using (var stream = new FileStream(_hostingEnvironment.WebRootPath + "/images/" + imageName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                product.Image = imageName;
            }
            _productService.CreateProduct(product);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(Guid guid)
        {
            Product product = _productService.GetProduct(guid);
            if (product == null)
            {
                ViewData["Message"] = "There is no Product with this Id";
                return View();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            Random random = new Random();
            if (file != null)
            {
                var imageName = random.Next() + file.FileName;
                using (var stream = new FileStream(_hostingEnvironment.WebRootPath + "/images/" + imageName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                product.Image = imageName;
            }
            _productService.EditProduct(product);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(Guid guid)
        {
            Product product = _productService.GetProduct(guid);
            if(product == null)
            {
                return View();
            }
            _productService.DeleteProduct(product);
            return RedirectToAction("List");
        }
    }
}