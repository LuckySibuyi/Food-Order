namespace FoodOrderApi.Models
{
    public class Order
    {
       public int OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;

    }
}
