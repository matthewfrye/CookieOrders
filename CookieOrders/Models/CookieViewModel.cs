using System.Collections.Generic;

namespace CookieOrders.Models
{
    public class CookieViewModel
    {
        [CookieListValidation(ErrorMessage = "Please select at least 1 box of cookies to order.")]
        public List<CookieDTO> Cookies { get; set; }
        public string DirectShipURL { get; private set; }

        public CookieViewModel()
        {

        }
        public CookieViewModel(List<Cookie> cookieList, string directShipURL)
        {
            DirectShipURL = directShipURL;

            Cookies = new List<CookieDTO>();
            foreach (Cookie cookie in cookieList)
            {
                if (cookie.OutOfStock == false)
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
}