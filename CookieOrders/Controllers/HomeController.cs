using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieOrders.Models;

namespace CookieOrders.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CookieViewModel cookieVM = new CookieViewModel();
            return View(cookieVM);
        }
        public IActionResult Order(CookieViewModel cookieOrder)
        {
            CookieOrderViewModel cookieOrderVM = new CookieOrderViewModel();
            for(int cookieCount = 0; cookieCount < cookieOrderVM.Cookies.Count; cookieCount++)
            {
                cookieOrderVM.Cookies[cookieCount].Amount = cookieOrder.Cookies[cookieCount].Amount;
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
