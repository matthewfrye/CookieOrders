using System.ComponentModel.DataAnnotations.Schema;

namespace CookieOrders.Models
{
    public class Cookie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CookieId { get; set; }
        public CookieType CookieType { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
        public decimal CostPerBox { get; set; }
        public string Description { get; set; }
    }
}
