using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        public int AmountDue { get; set; }

        public DateTime ScheduledDeliveryDate { get; set; }

        public DateTime DeliveredDate { get; set; }
    }
}
