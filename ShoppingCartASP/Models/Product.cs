using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Product Name")] [Required]
        public string Name { get; set; }

        [DisplayName("Product Color")]
        public string Color { get; set; }

        [DisplayName("Product Size")]
        public string Size { get; set; }

        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [DisplayName("Product Price")] [Required]
        public double price { get; set; }
    }
}
