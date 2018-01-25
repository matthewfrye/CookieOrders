using System;
using System.Collections.Generic;

namespace CookieOrders.Models
{
    public class CookieViewModel
    {
        public List<Cookie> Cookies { get; set; }
        public int test { get; set; }

        public CookieViewModel()
        {

            Cookies = new List<Cookie>();
            foreach (CookieType type in Enum.GetValues(typeof(CookieType)))
            {
                string path = "";
                switch (type)
                {
                    case CookieType.ThinMints:
                        path = "/images/ThinMints.jpg";
                        break;
                    case CookieType.CaramelDelites:
                        path = "/images/CaramelDelites.jpg";
                        break;
                    case CookieType.PeanutButterPatties:
                        path = "/images/PeanutButterPatties.jpg";
                        break;
                    case CookieType.Smores:
                        path = "/images/Smores.jpg";
                        break;
                    case CookieType.Lemonades:
                        path = "/images/Lemonades.jpg";
                        break;
                    case CookieType.ThanksAlots:
                        path = "/images/Thanksalot.jpg";
                        break;
                    case CookieType.Shortbread:
                        path = "/images/Shortbread.jpg";
                        break;
                    case CookieType.PeanutButterSandwiches:
                        path = "/images/PeanutButterSandwich.jpg";
                        break;
                    case CookieType.GlutenFreeTrios:
                        path = "/images/Trios.jpg";
                        break;
                    default:
                        break;
                }
                Cookies.Add(new Cookie { Type = type, ImagePath = path });

            }
        }
    }
}
