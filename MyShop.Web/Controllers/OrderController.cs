using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;
using System.Diagnostics;

namespace MyShop.Web.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = unitOfWork.OrderRepository.All();

            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            //Find a customer with the same customerId as the customer in the Order
            var customer = unitOfWork.CustomerRepository
                .Find(c => c.CustomerId == model.Customer.CustomerId)
                .FirstOrDefault();

            // If the customer exists, then assign the data
            // in the model to the customer to update that customer, else add customer.
            if (customer != null)
            {
                unitOfWork.CustomerRepository.Update(model.Customer);
                unitOfWork.SaveChanges();
            }
            else
            {
                unitOfWork.CustomerRepository.Add(model.Customer);
                unitOfWork.SaveChanges();
            }

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };

            if(order != null)
            {
                unitOfWork.OrderRepository.Add(order);
                unitOfWork.SaveChanges();

                return Ok("Order created successfully!");
            }
            else
            {
                return BadRequest("Order created failed!");
            }
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
