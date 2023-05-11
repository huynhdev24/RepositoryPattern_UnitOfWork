using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    [Table("LineItem")]
    public class LineItem
    {
        [Key]
        public Guid LineItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }

        public LineItem()
        {
            LineItemId = Guid.NewGuid();
        }
    }
}
