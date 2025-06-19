using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FoodOrderApi.Models;

namespace FoodOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        static private readonly List<Order> orders = new()
        {
            new() { OrderId = 1, OrderName = "Pizza", OrderDate = "2023-10-01", OrderStatus = "Delivered" },
            new() { OrderId = 2, OrderName = "Burger", OrderDate = "2023-10-02", OrderStatus = "Pending" }
        };

        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            return Ok(orders);
        }
    }
   
}
