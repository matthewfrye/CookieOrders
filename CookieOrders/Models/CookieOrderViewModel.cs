using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookieOrders.Models
{
    public class CookieOrderViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }

        public decimal TotalDue { get; set; }

        public int OrderId { get; set; }

        public List<Cookie> Cookies { get; set; }
        public List<CookieOrder> CookieOrders { get; set; }

        public CookieOrderViewModel()
        {

        }
    }
}