using System;

namespace CookieOrders.Models
{
    public class AdminViewModel
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public int NumberOfBoxes { get; set; }
        public string CookieType { get; set; }
        public decimal TotalAmountDue { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}