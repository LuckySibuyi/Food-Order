namespace FoodOrderApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int Quantity { get; set; }

        public Order() { }

        public Order(int orderId, string customerName, string? customerAddress, string? customerPhone, string? customerEmail, string? orderStatus, DateTime? orderDate, DateTime? deliveryDate, DateTime deliveryTime, int quantity)
        {
            OrderId = orderId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            OrderStatus = orderStatus;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            DeliveryTime = deliveryTime;
            Quantity = quantity;
        }
    }
}
