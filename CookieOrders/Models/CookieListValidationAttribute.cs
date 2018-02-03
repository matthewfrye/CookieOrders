using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CookieOrders.Models
{
    [AttributeUsage(AttributeTargets.Property |
      AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CookieListValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            int totalNumberOfBoxesOrdered = 0;
            foreach(CookieDTO cookieDTO in (List<CookieDTO>)value)
            {
                totalNumberOfBoxesOrdered += cookieDTO.Amount;
            }
            if (totalNumberOfBoxesOrdered == 0)
                result = false;

            return result;
        }
    }
}
