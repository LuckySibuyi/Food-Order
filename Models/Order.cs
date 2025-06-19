namespace FoodOrderApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? OrderName { get; set; }
        public string? OrderDate { get; set; }
        public string? OrderStatus { get; set; }
    }
}
