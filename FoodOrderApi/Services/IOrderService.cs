using FoodOrderApi.Models;

namespace FoodOrderApi.Services
{
    public interface IOrderService
    {
        List<Order> RetriveAllOrdersForCustomer();
        Order? RetriveSpecificOrderDetails(int orderId);
        void PlaceOrder(Order order);
        void ModifyOrder(Order order);
        void ModifyFoodQuantityInOrder(int orderId, int quantity);
        void CancelOrder(int orderId);
    }
}
