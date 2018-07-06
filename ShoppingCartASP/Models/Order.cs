using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ShoppingCartASP.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        internal string _Products { get; set; }

        internal string _Quantities { get; set; }

        [NotMapped]
        public int[] Quantities
        {
            get
            {
                return _Quantities == null ? null : JsonConvert.DeserializeObject<int[]>(_Quantities);
            }
            set
            {
                _Quantities = JsonConvert.SerializeObject(value);
            }
        }

        [NotMapped]
        public int[] Products
        {
            get
            {
                return _Products == null ? null : JsonConvert.DeserializeObject<int[]>(_Products);
            }
            set
            {
                _Products = JsonConvert.SerializeObject(value);
            }
        }
   

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Total Cost")]
        public double TotalCost { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
