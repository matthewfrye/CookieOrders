using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookieOrders.Models
{
    public class CookieOrderViewModel
    {
        public List<Cookie> Cookies { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddressLine1 { get; set; }

        public int TotalDue { get {
                int total = 0;
                foreach(var cookie in Cookies)
                {
                    if (cookie.Type == CookieType.GlutenFreeTrios)
                        total += cookie.Amount * 5;
                    else
                        total += cookie.Amount * 4;
                }
                return total;
            } }


        public CookieOrderViewModel()
        {

            Cookies = new List<Cookie>();
            foreach(CookieType type in Enum.GetValues(typeof(CookieType)))
            {
                Cookies.Add(new Cookie { Type = type });

            }
        }
    }
}
