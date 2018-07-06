using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCartASP.Models;
using ShoppingCartASP.Data;

namespace ShoppingCartASP.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
             _dbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            product.IsDeleted = true;
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id==id);
        }

        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            foreach(var product in _dbContext.Products)
            {
                if (!product.IsDeleted)
                    products.Add(product);
            }
            return products;
        }
    }
}
