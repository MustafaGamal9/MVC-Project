﻿namespace MVC_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // navigation property
        public ICollection<Product> Products { get; set; }
    }
}
