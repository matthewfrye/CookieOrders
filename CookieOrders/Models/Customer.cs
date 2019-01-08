using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public bool? Test { get; set; }
    }
}