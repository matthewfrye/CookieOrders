using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public decimal TotalAmountDue { get; set; }

        public DateTime? ScheduledDeliveryDate { get; set; }

        public DateTime? DeliveredDate { get; set; }
    }
}