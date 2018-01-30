using System;
using System.Collections.Generic;

namespace CookieOrders.Models
{
    public class CookieViewModel
    {
        public List<Cookie> Cookies { get; set; }

        public CookieViewModel()
        {

            Cookies = new List<Cookie>();
            foreach (CookieType type in Enum.GetValues(typeof(CookieType)))
            {
                string path = "";
                string description = "";
                switch (type)
                {
                    case CookieType.ThinMints:
                        path = "/images/ThinMints.jpg";
                        description = "Crispy chocolate wafers dipped in a mint chocolaty coating.";
                        break;
                    case CookieType.CaramelDelites:
                        path = "/images/CaramelDelites.jpg";
                        description = "Vanilla cookies topped with caramel, sprinkled with toasted coconut, and laced with chocolaty stripes.";
                        break;
                    case CookieType.PeanutButterPatties:
                        path = "/images/PeanutButterPatties.jpg";
                        description = "Crispy vanilla cookies layered with peanut butter and covered with a chocolaty coating.";
                        break;
                    case CookieType.Smores:
                        path = "/images/Smores.jpg";
                        description = "Crispy graham cookie double dipped in yummy crème icing and finished with a scrumptious chocolatey coating.";
                        break;
                    case CookieType.Lemonades:
                        path = "/images/Lemonades.jpg";
                        description = "Savory slices of shortbread with a refreshingly tangy lemon flavored icing.";
                        break;
                    case CookieType.ThanksAlots:
                        path = "/images/Thanksalot.jpg";
                        description = "Shortbread cookies dipped in rich fudge and topped with an embossed thank you message in one of 5 languages.";
                        break;
                    case CookieType.Shortbread:
                        path = "/images/Shortbread.jpg";
                        description = "Traditional shortbread cookies.";
                        break;
                    case CookieType.PeanutButterSandwiches:
                        path = "/images/PeanutButterSandwich.jpg";
                        description = "Crispy vanilla cookies layered with peanut butter and covered with a chocolaty coating.";
                        break;
                    case CookieType.GlutenFreeTrios:
                        path = "/images/Trios.jpg";
                        description = "Chocolate chips nestled in a gluten free peanut butter oatmeal cookie.";
                        break;
                    default:
                        break;
                }
                Cookies.Add(new Cookie { Type = type, ImagePath = path, Description = description });

            }
        }
    }
}
