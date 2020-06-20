using Moq;
using Ninject;
using SportsStore.Domain.Abstraction;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel k)
        {
            kernel = k;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //添加Product存储库的绑定（通过模仿的方式，以后需要时再改成真正的数据库）
            //Mock<IProductRepo> mock = new Mock<IProductRepo>();
            //mock.Setup(i => i.Products).Returns(new List<Product> {
            //    new Product(){ Name="Football", Price=25},
            //    new Product{Name="Surf board", Price=179},
            //    new Product(){Name="Running shoes", Price=95}
            //});
            //kernel.Bind<IProductRepo>().ToConstant(mock.Object);//每次请求存储库时返回的是同一个的对象，因此要用ToConstant
            //使用EF库代替模拟库
            kernel.Bind<IProductRepo>().To<EFProductRepo>();

            EmailSettings emailSettings = new EmailSettings()
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}