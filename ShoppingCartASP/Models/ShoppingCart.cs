using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Product []  products { get; set; }
        public int[] Quantities {get; set;}
    }
}
