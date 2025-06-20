using Microsoft.EntityFrameworkCore;

namespace FoodOrderApi.Data
{
    public class OrdersApicontext : DbContext
    {
        public OrdersApicontext(DbContextOptions<OrdersApicontext> options) : base(options)
        { 
        }
        public DbSet<FoodOrderApi.Models.Order> Orders { get; set; }

        
    } 
    
    
}
