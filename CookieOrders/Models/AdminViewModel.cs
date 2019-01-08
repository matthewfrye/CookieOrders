using System;
using System.ComponentModel.DataAnnotations;

namespace CookieOrders.Models
{
    public class AdminViewModel
    {
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Boxes")]
        public int NumberOfBoxes { get; set; }

        [Display(Name = "Type")]
        public string CookieType { get; set; }
        public decimal TotalAmountDue { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}