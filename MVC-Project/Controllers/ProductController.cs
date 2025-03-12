using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models.ViewModels; 


namespace ECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            var productVM = new ProductVM 
            {
                Products = products
            };

            return View(productVM); 
        }

        public IActionResult Details(int id)
        {


            var product = _context.Products.FirstOrDefault(m => m.Id == id);

            ViewBag.Product = product; // View Bag
            return View(product);
        }
    }
}