using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question_2.Models;

namespace Question_2.Controllers
{
    public class OrdersController : Controller
    {

        private PE_PRN_23SumContext _context;

        public OrdersController()
        {
            _context = new PE_PRN_23SumContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListByEmployee(int? id)
        {

            ViewData["employees"] = _context.Employees.ToList();
            List<Order> orders = null;
            if (id != null)
            {
                orders = _context.Orders.Where(o => o.EmployeeId == id).ToList();
            }
            else
            {
                orders = _context.Orders.ToList();
            }

            ViewData["orders"] = orders;

            return View();
        }

        public IActionResult Details(int? id)
        {
            List<OrderDetail> orderDetails = _context.OrderDetails.Where(o => o.OrderId == id).Include(od => od.Product).ThenInclude(prod => prod.Category).ToList();
            ViewBag.Order = _context.Orders.Include(o => o.Employee).FirstOrDefault(o => o.OrderId == id); ;
            return View(orderDetails);
        }
    }
}
