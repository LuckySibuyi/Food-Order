using FoodOrderApi.Models;
using System.Collections.Generic;

namespace FoodOrderApi.Data.Repository
{
    public interface IFoodRepository
    {
        void InsertOrder(Order order);
        List<Order> FetchAllOrdersForCustomer();
        Order FetchSpecificOrderDetails(int orderId);
        void UpdateFoodQuantityInOrder(int orderId, int quantity);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
