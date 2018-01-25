using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieOrders.Models
{
    public static class HtmlLists
    {
        public static IEnumerable<CookieAmount> CookieAmounts = new List<CookieAmount> {
    new CookieAmount {
        Value = 0,
        Text = "0"
    },
    new CookieAmount {
        Value = 1,
        Text = "1"
    },
    new CookieAmount {
        Value = 2,
        Text = "2"
    },
    new CookieAmount {
        Value = 3,
        Text = "3"
    },
    new CookieAmount {
        Value = 4,
        Text = "4"
    },
    new CookieAmount {
        Value = 5,
        Text = "5"
    },
    new CookieAmount {
        Value = 6,
        Text = "6"
    },
    new CookieAmount {
        Value = 7,
        Text = "7"
    },
    new CookieAmount {
        Value = 8,
        Text = "8"
    },
    new CookieAmount {
        Value = 9,
        Text = "9"
    }
};
    }

    public class CookieAmount
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
