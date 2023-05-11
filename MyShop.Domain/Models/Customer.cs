using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        public Customer(Customer customer)
        {
            this.CustomerId = customer.CustomerId; 
            this.Name = customer.Name; 
            this.ShippingAddress = customer.ShippingAddress;
            this.City = customer.City; 
            this.PostalCode = customer.PostalCode; 
            this.Country = customer.Country;
        }
    }
}
