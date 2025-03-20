using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cat = _context.Categories.ToList();
            ViewData["Categories"] = cat; // View Data
            return View();
        }

        public IActionResult Details(int id)
        {

            var cat = _context.Categories.FirstOrDefault(m => m.Id == id);

            ViewBag.Category = cat;  // View Bag
            return View(cat);
        }
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(Category category)
        {

             _context.Categories.Add(category);
             _context.SaveChanges();
              return RedirectToAction(nameof(Index));
        }

      
        public IActionResult Update(int? id)
        {

            var category = _context.Categories.Find(id);
            return View(category);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category category)
        {
   
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
           
  
        }

        public IActionResult Delete(int? id)
        {
   

            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult saveDelete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}