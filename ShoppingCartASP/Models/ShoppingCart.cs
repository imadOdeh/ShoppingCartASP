using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Models
{
    public class ShoppingCart
    {
        public Product []  products { get; set; }
        public int[] Quantities {get; set;}
    }
}
