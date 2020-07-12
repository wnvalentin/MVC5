using MvcModels.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Models
{
    //[Bind(Include ="City")]
    //通过特性指定模型绑定器
    [ModelBinder(typeof(AddressSummaryBinder))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}