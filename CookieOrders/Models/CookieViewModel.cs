using System.Collections.Generic;

namespace CookieOrders.Models
{
    public class CookieViewModel
    {
        public List<CookieDTO> Cookies { get; set; }

        public CookieViewModel()
        {

        }
        public CookieViewModel(List<Cookie> cookieList)
        {
            Cookies = new List<CookieDTO>();
            foreach (Cookie cookie in cookieList)
            {
                Cookies.Add(new CookieDTO()
                {
                    CookieId = cookie.CookieId,
                    CookieType = cookie.CookieType,
                    ImagePath = cookie.ImagePath,
                    Name = cookie.Name,
                    Description = cookie.Description
                });
            }
        }
    }
}