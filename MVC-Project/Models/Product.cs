namespace MVC_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        // foreign  key
        public int CategoryId { get; set; }

         // navigation property
         public Category Category { get; set; }
         public ICollection<OrderItem> OrderItems { get; set; }
    }
}
