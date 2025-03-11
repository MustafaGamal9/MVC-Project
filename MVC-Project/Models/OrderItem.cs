namespace MVC_Project.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // navigation property
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
