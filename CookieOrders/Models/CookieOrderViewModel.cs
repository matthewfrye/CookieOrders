using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookieOrders.Models
{
    public class CookieOrderViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
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