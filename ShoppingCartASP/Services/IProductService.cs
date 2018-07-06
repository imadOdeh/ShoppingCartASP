using ShoppingCartASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> Products();
        Product GetProduct(int id);
    }
}
