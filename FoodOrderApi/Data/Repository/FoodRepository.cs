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
            order.OrderId = _nextId++;
            order.OrderStatus ??= "Placed";
            order.OrderDate ??= DateTime.Now;
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
            order.OrderStatus = updatedOrder.OrderStatus;
            order.OrderDate = updatedOrder.OrderDate;
            order.DeliveryDate = updatedOrder.DeliveryDate;
            order.DeliveryTime = updatedOrder.DeliveryTime;
            order.Quantity = updatedOrder.Quantity;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new Exception("Order not found");

            _orders.Remove(order);
        }
    }
}
