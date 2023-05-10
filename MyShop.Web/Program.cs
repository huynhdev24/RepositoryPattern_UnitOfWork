
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Infrastructure;

namespace MyShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            CreateInitialDatabase();
            builder.Services.AddTransient<ShoppingContext>();
            builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
            builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/order/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static void CreateInitialDatabase()
        {
            using (var context = new ShoppingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var camera = new Product { Name = "Canon EOS 70D", Price = 599m };
                var microphone = new Product { Name = "Shure SM7B", Price = 245m };
                var light = new Product { Name = "Key Light", Price = 59.99m };
                var phone = new Product { Name = "Android Phone", Price = 259.59m };
                var speakers = new Product { Name = "5.1 Speaker System", Price = 799.99m };

                var productRepository = new ProductRepository(context);

                productRepository.Add(camera);
                productRepository.Add(microphone);
                productRepository.Add(light);
                productRepository.Add(phone);
                productRepository.Add(speakers);

                productRepository.SaveChanges();
            }
        }
    }
}