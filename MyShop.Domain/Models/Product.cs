using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
