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
        public DateTime? DeliveryDate { get; private set; }
        public DateTime? DeliveryTime { get; private set; }

        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var orders = _orderService.RetriveAllOrdersForCustomer();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(int orderId)
        {
            var order = _orderService.RetriveSpecificOrderDetails(orderId);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(order);
        }

        [HttpPost]
        public ActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                _orderService.PlaceOrder(order);
                return StatusCode(201, new { message = "Order Placed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{orderId}")]
        public ActionResult ModifyOrder(int orderId, [FromBody] Order order)
        {
            try
            {
                order.OrderId = orderId;
                _orderService.ModifyOrder(order);
                return Ok(new { message = "Order Modified" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Order not found")
                    return NotFound(new { message = ex.Message });

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{orderId}/quantity/{quantity}")]
        public ActionResult ModifyFoodQuantity(int orderId, int quantity)
        {
            try
            {
                _orderService.ModifyFoodQuantityInOrder(orderId, quantity);
                return Ok(new { message = "Quantity updated" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Order not found")
                    return NotFound(new { message = ex.Message });

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public ActionResult CancelOrder([FromQuery] int orderid)
        {
            try
            {
                _orderService.CancelOrder(orderid);
                return Ok(new { message = "Order Cancelled" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Order not found")
                    return NotFound(new { message = ex.Message });

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
