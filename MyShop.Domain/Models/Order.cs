using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid OrderId { get; private set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        // SQLite doesn't support DateTimeOffset :(
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal => LineItems.Sum(item => item.Product.Price * item.Quantity);

        public Order()
        {
            OrderId = Guid.NewGuid();

            OrderDate = DateTime.UtcNow;
        }
    }
}
