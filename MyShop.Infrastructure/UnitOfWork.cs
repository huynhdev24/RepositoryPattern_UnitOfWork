using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Product> ProductRepository { get; }

        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext context;
        private IRepository<Customer> customerRepository;
        private IRepository<Order> orderRepository;
        private IRepository<Product> productRepository;

        public UnitOfWork(ShoppingContext context)
        {
            this.context = context;
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(context);
                }

                return customerRepository;
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
                }

                return orderRepository;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }

                return productRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
