using CookieOrders.Data;
using CookieOrders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CookieOrders.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(CustomerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                    OrderId = cookieOrderVM.OrderId,
                    Test = cookieOrderVM.Email == _configuration.GetSection("AppSettings").GetSection("AdminEmailAddress").Value ? true : false
                };
                _context.Customer.Add(customer);
                _context.SaveChanges();

                SendEmails(cookieOrderVM.Email, cookieOrderVM.OrderId, customer.CustomerId);

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

        private void SendEmails(string customerEmail, int orderId, int customerId)
        {
            //todo - move these to tokenized values in CI process
            string orderAlertEmailAddresses = _configuration.GetSection("AppSettings").GetSection("OrderAlertEmailAddresses").Value;

            SendEmail(customerEmail, orderId, customerId, true);
            SendEmail(orderAlertEmailAddresses, orderId,customerId, false);
        }

        private void SendEmail(string emailAddress, int orderId, int customerId, bool customerEmail)
        {
            string adminEmailAddress = _configuration.GetSection("AppSettings").GetSection("AdminEmailAddress").Value;
            string adminEmailPassword = _configuration.GetSection("AppSettings").GetSection("AdminEmailPassword").Value;
            string adminEmailDisplayName = _configuration.GetSection("AppSettings").GetSection("AdminEmailDisplayName").Value;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(adminEmailAddress, adminEmailPassword);
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress(adminEmailAddress, adminEmailDisplayName);

            foreach (string email in emailAddress.Split(',').ToList())
            {
                mail.To.Add(new MailAddress(email));
            }

            if (customerEmail)
            {

                mail.Subject = "Thank you for your Girl Scout Cookie order!";
                mail.Body = GetEmailWording(customerId);
            }
            else
            {
                mail.Subject = "Someone ordered Cookies!!";
                //todo - add link below with a way to view the order in the manager screen
                mail.Body = $"Check here - https://{_configuration.GetSection("AppSettings").GetSection("WebsiteDomain").Value}/SuperAdmin/View/{customerId}";
            }

            smtpClient.Send(mail);
        }

        private string GetEmailWording(int customerId)
        {
            string emailWording = "Thank you for ordering from Lexi the Cookie Girl!  Lexi will email soon with details on when the cookies can be delivered.  Cookies can be paid for with cash, check (payable to Troop 2136), or credit card.  If you have any questions, you can reach Lexi by email - lexithecookiegirl@gmail.com.  Order details are below.\n\n";

            var customer = _context.Customer
                .Include(o => o.Order)
                    .ThenInclude(co => co.CookieOrders)
                    .ThenInclude(c => c.Cookie)
                .SingleOrDefault(i => i.CustomerId == customerId);
            
            foreach (CookieOrder cookieOrder in customer.Order.CookieOrders)
            {
                emailWording = string.Concat(emailWording, $"{cookieOrder.NumberOfBoxes} {cookieOrder.Cookie.Name}\n");
            }

            emailWording = string.Concat(emailWording, $"Total owed = ${customer.Order.TotalAmountDue}");
            return emailWording;
        }
    }
}