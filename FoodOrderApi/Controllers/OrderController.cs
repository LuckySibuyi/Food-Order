using FoodOrderApi.Models;
using FoodOrderApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            return Ok(_orderService.RetriveAllOrdersForCustomer());
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(int orderId)
        {
            var order = _orderService.RetriveSpecificOrderDetails(orderId);
            return order == null ? NotFound("Order not found") : Ok(order);
        }

        [HttpPost]
        public ActionResult<string> CreateOrder([FromBody] Order order)
        {
            _orderService.PlaceOrder(order);
            return StatusCode(201, "Order Placed");
        }

        [HttpPut("{orderId}")]
        public ActionResult<string> ModifyOrder(int orderId, [FromBody] Order order)
        {
            order.OrderId = orderId;
            _orderService.ModifyOrder(order);
            return Ok("Order Modified");
        }

        [HttpPatch("{orderId}/quantity/{quantity}")]
        public ActionResult<string> ModifyFoodQuantity(int orderId, int quantity)
        {
            _orderService.ModifyFoodQuantityInOrder(orderId, quantity);
            return Ok("Quantity updated");
        }

        [HttpDelete]
        public ActionResult<string> CancelOrder([FromQuery] int orderid)
        {
            _orderService.CancelOrder(orderid);
            return Ok("Order Cancelled");
        }
    }
}
