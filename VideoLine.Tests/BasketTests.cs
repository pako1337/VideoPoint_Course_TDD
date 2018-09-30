﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoLine.Models;

namespace VideoLine.Tests
{
    public class BasketTests
    {
        [Test]
        public void ShouldCreateEmptyBasket()
        {
            var basket = new Basket();

            Assert.AreEqual(0, basket.Count());
        }

        [Test]
        public void ShouldReturnBasketCountWhenOneCourseAdded()
        {
            var basket = new Basket();

            basket.Add(new Course());

            Assert.AreEqual(1, basket.Count());
        }
    }
}
