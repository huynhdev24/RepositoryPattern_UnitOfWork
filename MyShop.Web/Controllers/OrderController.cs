using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;
using System.Diagnostics;

namespace MyShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;

        public OrderController(IRepository<Order> orderRepository,
             IRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = orderRepository.Find(order => order.OrderDate > DateTime.UtcNow.AddDays(-1));

            return Ok(orders);
        }

        [HttpPost]
        public IActionResult GetAllOrders()
        {
            var products = productRepository.All();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };

            orderRepository.Add(order);

            orderRepository.SaveChanges();

            return Ok("Order Created");
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
