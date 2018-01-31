using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookieOrders.Models;
using CookieOrders.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CookieOrders.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerContext _context;
        public HomeController(CustomerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            CookieViewModel cookieVM = new CookieViewModel(await _context.Cookie.ToListAsync());
            return View(cookieVM);
        }

        public async Task<IActionResult> Order(CookieViewModel cookieVM)
        {
            Order order = new Order();
            _context.Order.Add(order);
            _context.SaveChanges();
            List<Cookie> cookies = await _context.Cookie.ToListAsync();

            for (int cookieCount = 0; cookieCount < cookies.Count; cookieCount++)
            {
                if(cookieVM.Cookies[cookieCount].Amount > 0)
                { 
                    CookieOrder cookieOrder = new CookieOrder();
                    cookieOrder.Cookie = cookies[cookieCount];
                    cookieOrder.OrderId = order.OrderId;
                    cookieOrder.CookieId = cookies[cookieCount].CookieId;
                    cookieOrder.NumberOfBoxes = cookieVM.Cookies[cookieCount].Amount;
                    _context.CookieOrder.Add(cookieOrder);

                    order.TotalAmountDue = order.TotalAmountDue + (cookieVM.Cookies[cookieCount].Amount * cookies[cookieCount].CostPerBox);
                }
            }
            _context.Order.Update(order);
            _context.SaveChanges();

            CookieOrderViewModel cookieOrderVM = new CookieOrderViewModel();
            return View("CookieOrder", cookieOrderVM);
        }
    
        public IActionResult CookieOrder(CookieOrderViewModel cookieOrder)
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Email Lexi if you're having problems with the site.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
