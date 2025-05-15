using FoodOrderApi.Models;

namespace FoodOrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new();
        private int _nextId = 1;

        public List<Order> RetriveAllOrdersForCustomer()
        {
            return _orders;
        }

        public Order? RetriveSpecificOrderDetails(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void PlaceOrder(Order order)
        {
            order.OrderId = _nextId++;
            order.SetOrderDate(DateTime.Now);
            order.SetOrderStatus("Pending");
            _orders.Add(order);
        }

        public void ModifyOrder(Order updatedOrder)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
            if (existingOrder == null)
                throw new Exception("Order not found");

            existingOrder.CustomerName = updatedOrder.CustomerName;
            existingOrder.CustomerAddress = updatedOrder.CustomerAddress;
            existingOrder.CustomerPhone = updatedOrder.CustomerPhone;
            existingOrder.CustomerEmail = updatedOrder.CustomerEmail;

            existingOrder.SetOrderStatus(updatedOrder.OrderStatus ?? existingOrder.OrderStatus);
            existingOrder.SetOrderDate(updatedOrder.OrderDate ?? existingOrder.OrderDate ?? DateTime.Now);
            existingOrder.SetDeliveryDate(updatedOrder.DeliveryDate ?? existingOrder.DeliveryDate ?? DateTime.Now);
            existingOrder.SetDeliveryTime(updatedOrder.DeliveryTime != default ? updatedOrder.DeliveryTime : existingOrder.DeliveryTime);

            existingOrder.Quantity = updatedOrder.Quantity;
        }

        public void ModifyFoodQuantityInOrder(int orderId, int quantity)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder == null)
                throw new Exception("Order not found");

            existingOrder.Quantity = quantity;
        }

        public void CancelOrder(int orderId)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder == null)
                throw new Exception("Order not found");

            existingOrder.SetOrderStatus("Cancelled");
        }
    }
}
