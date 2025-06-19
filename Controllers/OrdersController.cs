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

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }
            order.OrderId = orders.Count + 1;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }


        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = orders.FirstOrDefault(x => x.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order updatedOrder)
        {
            var order = orders.FirstOrDefault(x => x.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderId = updatedOrder.OrderId;
            order.OrderName = updatedOrder.OrderName;
            order.OrderDate = updatedOrder.OrderDate;
            order.OrderStatus = updatedOrder.OrderStatus;

            return NoContent();
        }

    }
    
   
}
