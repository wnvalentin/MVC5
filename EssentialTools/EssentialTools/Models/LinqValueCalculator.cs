using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discount;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper helper)
        {
            discount = helper;
            System.Diagnostics.Debug.WriteLine($"第{++counter}个实例被创建");
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discount.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}