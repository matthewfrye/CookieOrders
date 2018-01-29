using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookieOrders.Models;
using CookieOrders.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            //cookieVM.Cookies = await _context.Cookie.ToListAsync();
            return View(cookieVM);
        }

        public IActionResult Order(CookieViewModel cookieVM)
        {
            //Order order = new Order();
            
            foreach( CookieDTO cookie in cookieVM.Cookies)
            {
                if(cookie.Amount >0)
                {
                    CookieOrder cookieOrder = new CookieOrder();
                    cookieOrder.Cookies.Add(cookie.ToCookie());
                    cookieOrder.
                }
                //order.AmountDue += cookie.Am
            }
            

            CookieOrderViewModel cookieOrderVM = new CookieOrderViewModel();
            for(int cookieCount = 0; cookieCount < cookieOrderVM.Cookies.Count; cookieCount++)
            {
                //cookieOrderVM.Cookies[cookieCount].Amount = cookieOrder.Cookies[cookieCount].Amount;
            }
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
