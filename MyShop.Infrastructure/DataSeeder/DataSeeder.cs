using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.DataSeeder
{
    public class DataSeeder
    {
        public void CreateInitialDatabase()
        {
            //using (var context = new ShoppingContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();

            //    var camera = new Product { Name = "Canon EOS 70D", Price = 599m };
            //    var microphone = new Product { Name = "Shure SM7B", Price = 245m };
            //    var light = new Product { Name = "Key Light", Price = 59.99m };
            //    var phone = new Product { Name = "Android Phone", Price = 259.59m };
            //    var speakers = new Product { Name = "5.1 Speaker System", Price = 799.99m };

            //    var productRepository = new ProductRepository(context);

            //    productRepository.Add(camera);
            //    productRepository.Add(microphone);
            //    productRepository.Add(light);
            //    productRepository.Add(phone);
            //    productRepository.Add(speakers);

            //    productRepository.SaveChanges();
            //}
        }
    }
}
