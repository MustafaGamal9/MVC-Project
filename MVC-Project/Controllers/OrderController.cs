using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace ECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.Customer) //  Customer details
                .ToList();

             var ordervm = new OrderVM // View Model
             {
                Orders = orders
             };

            return View(ordervm);
        }

        public IActionResult Details(int id)
        {

           var order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product) 
                .FirstOrDefault(m => m.Id == id);


            var orderDetailsvm = new OrderDetailsVM // View Model 
            {
                Order = order
               
            };

            return View(orderDetailsvm);


        }

     
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(Order order)
        {

             _context.Orders.Add(order);
             _context.SaveChanges();
             return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
 

            var order = _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
            ViewBag.Customers = _context.Customers.ToList(); 
            return View(order);
        }

     
        [HttpPost]
        public IActionResult Update(int id, Order order)
        {


            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int? id)
        {
 
            var order = _context.Orders.FirstOrDefault(m => m.Id == id);
            return View(order);
        }

   
        [HttpPost, ActionName("Delete")]
        public IActionResult saveDelete(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}