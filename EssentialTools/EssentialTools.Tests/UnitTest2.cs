﻿using System;
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

        private Product[] createProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            //arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(d => d.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(n => n);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).
                Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => (total * 0.9M));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);

            // act
            decimal FiveDollarDiscount =
            target.ValueProducts(createProduct(5));
            decimal TenDollarDiscount =
            target.ValueProducts(createProduct(10));
            decimal FiftyDollarDiscount =
            target.ValueProducts(createProduct(50));
            decimal HundredDollarDiscount =
            target.ValueProducts(createProduct(100));
            decimal FiveHundredDollarDiscount =
            target.ValueProducts(createProduct(500));

            // assert
            Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");
            target.ValueProducts(createProduct(0));
        }
    }
}
