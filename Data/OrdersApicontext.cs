using Microsoft.EntityFrameworkCore;
using FoodOrderApi.Models;

namespace FoodOrderApi.Data
{
    public class OrdersApicontext : DbContext
    {
        public OrdersApicontext(DbContextOptions<OrdersApicontext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderName = "Pizza", OrderDate = "2023-10-01", OrderStatus = "Delivered" },
                new Order { OrderId = 2, OrderName = "Burger", OrderDate = "2023-10-02", OrderStatus = "Pending" }
            );
        }
        public DbSet<FoodOrderApi.Models.Order> Orders { get; set; }

        
    } 
    
    
}
