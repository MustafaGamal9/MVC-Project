using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
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

       
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList(); 
            return View();
        }

        
        [HttpPost]
      
        public IActionResult Create(Product product)
        {

           _context.Products.Add(product);
           _context.SaveChanges();
           return RedirectToAction(nameof(Index));
          
        }

        
        public IActionResult Edit(int? id)
        {


            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        
        [HttpPost]
        public IActionResult Update(int id, Product product)
        {

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
 
        }


        public IActionResult Delete(int? id)
        {

            var product = _context.Products.FirstOrDefault(m => m.Id == id);

            return View(product);
        }

   
        [HttpPost, ActionName("Delete")]
        public IActionResult saveDelete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}