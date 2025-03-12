using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

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
    }
}