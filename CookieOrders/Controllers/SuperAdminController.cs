using CookieOrders.Data;
using CookieOrders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CookieOrders.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly CustomerContext _context;

        public SuperAdminController(CustomerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IList<AdminViewModel> adminViewModelList = GetNonTestOrders();
            return View(adminViewModelList);
        }

        public IActionResult OrdersToDeliver()
        {

            IList<AdminViewModel> adminViewModelList = GetNonTestOrders();
            //remove orders with a Delivered Date
            IEnumerable<AdminViewModel> ordersToDeliverList = adminViewModelList.Where(m => m.DeliveredDate == null);

            return View(ordersToDeliverList);
        }

        private IList<AdminViewModel> GetNonTestOrders()
        {

            IList<AdminViewModel> adminViewModelList = new List<AdminViewModel>();
            List<Order> orders = _context.Order.ToList();
            foreach (Order order in orders)
            {

                if (order.TotalAmountDue > 0)
                {
                    Customer customer = _context.Customer.FirstOrDefault(m => m.OrderId == order.OrderId);
                    if (customer != null && customer.Name.Length > 0 && (customer.Test == null || customer.Test == false))
                    {
                        IEnumerable<CookieOrder> cookieOrderList = _context.CookieOrder.Where(c => c.OrderId == customer.OrderId);
                        foreach (CookieOrder cookieOrder in cookieOrderList)
                        {

                            AdminViewModel adminViewModel = new AdminViewModel()
                            {
                                City = customer.City,
                                TotalAmountDue = order.TotalAmountDue,
                                CustomerName = customer.Name,
                                Address = customer.Address,
                                EmailAddress = customer.Email,
                                NumberOfBoxes = cookieOrder.NumberOfBoxes,
                                DeliveredDate = order.DeliveredDate
                            };

                            adminViewModel.CookieType = ((Cookie)_context.Cookie.SingleOrDefault(co => co.CookieId == cookieOrder.CookieId)).Name;
                            adminViewModelList.Add(adminViewModel);
                        }

                    }

                }
            }

            return adminViewModelList;
        }
    }
}