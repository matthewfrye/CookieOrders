using CookieOrders.Data;
using CookieOrders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookieOrders.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IList<Cookie> cookies = await _context.Cookie.ToListAsync();

            return View(await _context.Customer.ToListAsync());
        }
    }
}
