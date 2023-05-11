using MyShop.Domain.Models;

namespace MyShop.Web.Models
{
    public class CreateOrderModel
    {
        public IEnumerable<LineItem> LineItems { get; set; }

        public Customer Customer { get; set; }
    }
}
