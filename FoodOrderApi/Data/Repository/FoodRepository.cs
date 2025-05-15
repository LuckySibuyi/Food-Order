using FoodOrderApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderApi.Data.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly List<Order> _orders = new();
        private int _nextId = 1;

        public void InsertOrder(Order order)
        {
            order.SetOrderStatus("Placed"); // Use the setter method instead of direct assignment
            order.SetOrderDate(DateTime.Now); // Use the setter method instead of direct assignment
            order.OrderId = _nextId++;
            _orders.Add(order);
        }


        public List<Order> FetchAllOrdersForCustomer()
        {
            return _orders;
        }

        public Order FetchSpecificOrderDetails(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new Exception("Order not found");

            return order;
        }

        public void UpdateFoodQuantityInOrder(int orderId, int quantity)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.Quantity = quantity;
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
            if (order == null)
                throw new Exception("Order not found");

            order.CustomerName = updatedOrder.CustomerName;
            order.CustomerAddress = updatedOrder.CustomerAddress;
            order.CustomerPhone = updatedOrder.CustomerPhone;
            order.CustomerEmail = updatedOrder.CustomerEmail;
            order.SetOrderStatus(updatedOrder.OrderStatus ?? throw new ArgumentNullException(nameof(updatedOrder.OrderStatus)));
            order.SetOrderDate(updatedOrder.OrderDate ?? throw new ArgumentNullException(nameof(updatedOrder.OrderDate))); // Use the setter method
            if (updatedOrder.DeliveryDate.HasValue)
            {
                order.SetDeliveryDate(updatedOrder.DeliveryDate.Value); // Use the setter method
            }
            order.SetDeliveryTime(updatedOrder.DeliveryTime); // Use the setter method
            order.Quantity = updatedOrder.Quantity;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new Exception("Order not found");

            _orders.Remove(order);
        }
        // Setter methods for properties that are private set
        public void SetOrderStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Order status cannot be null or empty.", nameof(status));
            }
            OrderStatus = status;
        }
    }
}
