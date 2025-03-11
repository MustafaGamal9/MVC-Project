namespace MVC_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // foreign key
        public int CustomerId { get; set; }
        
        // navigation property
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
