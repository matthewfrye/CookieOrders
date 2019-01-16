using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Total Amount Due")]
        public decimal TotalAmountDue { get; set; }

        public DateTime? ScheduledDeliveryDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public IEnumerable<CookieOrder> CookieOrders { get; set; }
    }
}