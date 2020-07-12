using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country") > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            //只对country属性的值进行响应，且只返回USA
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture);
            }
            return null;
        }
    }
}