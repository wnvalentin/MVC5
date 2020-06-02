using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            if (total < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (total > 100)
            {
                return total * 0.9M;
            }
            else if (total >= 10 && total <= 100)
            {
                return total - 5;
            }
            else
            {
                return total;
            }
        }
    }
}