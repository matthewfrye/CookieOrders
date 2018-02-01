using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieOrders.Models
{
    public class CookieDTO
    {
        public int CookieId { get; set; }
        public CookieType CookieType { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
        public string Description { get; set; }

        public int Amount { get; set; }

        public Cookie ToCookie()
        {
            Cookie cookie = new Cookie
            {
                CookieId = CookieId,
                CookieType = CookieType,
                Name = Name,
                ImagePath = ImagePath,
                Description = Description
            };

            Cookie cookie = new Cookie();
            cookie.CookieId = CookieId;
            cookie.CookieType = CookieType;
            cookie.Name = Name;
            cookie.ImagePath = ImagePath;
            cookie.Description = Description;

            return cookie;
        }
    }
}

