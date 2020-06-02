using System;
using System.Collections.Generic;
using System.Linq;
using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price =275M},
            new Product {Name = "Lifejacket", Category = "Watersports",Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price= 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price= 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            // arrange
            //var discounter = new MinimumDiscountHelper();

            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(d => d.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(t => t);

            var target = new LinqValueCalculator(mock.Object);

            var goalTotal = products.Sum(e => e.Price);
            // act
            var result = target.ValueProducts(products);
            // assert
            Assert.AreEqual(goalTotal, result);
        }
    }
}
