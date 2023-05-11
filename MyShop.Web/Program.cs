
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

            //builder.Services.AddTransient<ShoppingContext>();
            builder.Services.AddDbContext<ShoppingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            //builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            //builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
            //builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
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
    }
}