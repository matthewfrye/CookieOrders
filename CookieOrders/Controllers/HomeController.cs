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

            if (ModelState.IsValid)
            {
                Order order = new Order();
                _context.Order.Add(order);
                _context.SaveChanges();
                List<Cookie> cookies = await _context.Cookie.ToListAsync();

                CookieOrderViewModel cookieOrderVM = new CookieOrderViewModel
                {
                    Cookies = cookies,
                    CookieOrders = new List<CookieOrder>(),
                    OrderId = order.OrderId
                };
                for (int cookieCount = 0; cookieCount < cookies.Count; cookieCount++)
                {
                    if (cookieVM.Cookies[cookieCount].Amount > 0)
                    {

                        CookieOrder cookieOrder = new CookieOrder
                        {
                            Cookie = cookies[cookieCount],
                            OrderId = order.OrderId,
                            CookieId = cookies[cookieCount].CookieId,
                            NumberOfBoxes = cookieVM.Cookies[cookieCount].Amount
                        };
                        _context.CookieOrder.Add(cookieOrder);
                        cookieOrderVM.CookieOrders.Add(cookieOrder);

                        order.TotalAmountDue = order.TotalAmountDue + (cookieVM.Cookies[cookieCount].Amount * cookies[cookieCount].CostPerBox);
                    }
                }
                _context.Order.Update(order);
                _context.SaveChanges();

                cookieOrderVM.TotalDue = order.TotalAmountDue;

                return View("CookieOrder", cookieOrderVM);
            }
            CookieViewModel cookieErrorVM = new CookieViewModel(await _context.Cookie.ToListAsync());
            return View("Index", cookieErrorVM);
        }

        public IActionResult CookieOrder(CookieOrderViewModel cookieOrderVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    Name = cookieOrderVM.Name,
                    Address = cookieOrderVM.Address,
                    City = cookieOrderVM.City,
                    Email = cookieOrderVM.Email,
                    OrderId = cookieOrderVM.OrderId
                };
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return View("ConfirmedOrder");
            }

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