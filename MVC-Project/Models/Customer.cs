namespace MVC_Project.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // navigation property
        public ICollection<Order> Orders { get; set; }
    }
}
