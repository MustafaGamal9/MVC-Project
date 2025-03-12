using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

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
    }
}