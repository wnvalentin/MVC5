using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal total);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal total)
        {
            return (1 - DiscountSize / 100) * total;
        }
    }

    public class DefaultDiscountHelper2 : IDiscountHelper
    {
        private decimal discountSize { get; set; }

        public DefaultDiscountHelper2(decimal discountNumber)
        {
            discountSize = discountNumber;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return (1 - discountSize / 100) * total;
        }
    }
}
