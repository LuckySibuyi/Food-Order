namespace FoodOrderApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }

        // Make these properties read-only outside and settable only via methods
        public string? OrderStatus { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public DateTime? DeliveryDate { get; private set; }
        public DateTime DeliveryTime { get; private set; }
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

        // Setter methods for properties that are private set
        public void SetOrderStatus(string status)
        {
            OrderStatus = status;
        }

        public void SetOrderDate(DateTime date)
        {
            OrderDate = date;
        }

        public void SetDeliveryDate(DateTime date)
        {
            DeliveryDate = date;
        }

        public void SetDeliveryTime(DateTime time)
        {
            DeliveryTime = time;
        }
    }
}
