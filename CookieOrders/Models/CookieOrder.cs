using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class CookieOrder
    {
        //public IList<Cookie> Cookies { get; set; }
        //public string Name { get; set; }
        //public string AddressLine1 { get; set; }
        //public string City { get; set; }
        //public string Email { get; set; }
        public Cookie Cookie { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CookieOrderId { get; set; }
        public int CookieId { get; set; }
        public int OrderId { get; set; }
        public int NumberOfBoxes { get; set; }
    }
}
