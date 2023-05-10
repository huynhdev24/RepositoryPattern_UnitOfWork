using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> repository;

        public CustomerController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = repository.All();

                return Ok(customers);
            }
            else
            {
                var customer = repository.Get(id.Value);

                return Ok(new[] { customer });
            }
        }
    }
}
