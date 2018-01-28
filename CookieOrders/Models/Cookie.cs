using System;
using System.ComponentModel;
using System.Reflection;

namespace CookieOrders.Models
{
    public class Cookie
    {
        public CookieType Type { get; set; }

        public string Name 
            {
            get { return GetEnumDescription(Type); }
            }

        public int Amount { get; set; }

        public string ImagePath { get; set; }

        public Cookie()
        {

        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }


}
