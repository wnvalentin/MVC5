using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Web.Controllers;
using SportsStore.Web.Infrastructure.Abstrct;
using SportsStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class AdminSecurityTest
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "123456")).Returns(true);

            LoginViewModel model = new LoginViewModel { UserName = "admin", Password = "123456" };

            AccountController target = new AccountController(mock.Object);
            ActionResult result = target.Login(model, "/MyUrl");
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyUrl", ((RedirectResult)result).Url);
        }
    }
}
