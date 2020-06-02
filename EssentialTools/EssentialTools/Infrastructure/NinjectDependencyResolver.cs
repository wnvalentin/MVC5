using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver :IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel ker)
        {
            kernel = ker;
            AddBindings();
        }
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();
            //带有属性参数值
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50m);
            //构造函数带有参数
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper2>().WithConstructorArgument("discountNumber", 50m);
        }


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}