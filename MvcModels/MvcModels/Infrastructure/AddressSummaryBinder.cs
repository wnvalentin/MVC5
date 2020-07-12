using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            AddressSummary model = (AddressSummary)bindingContext.Model ?? new AddressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            return model;
        }


        private string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult rst = context.ValueProvider.GetValue(name);
            if (rst == null || rst.AttemptedValue == "")
            {
                return "<Not Specified>";
            }
            else
            {
                return (string)rst.AttemptedValue;
            }
        }

    }
}