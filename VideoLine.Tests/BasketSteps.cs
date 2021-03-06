﻿using System;
using Should;
using TechTalk.SpecFlow;
using VideoLine.Models;

namespace VideoLine.Tests
{
    [Binding, Scope(Tag = "AddingToBasket")]
    public class BasketSteps
    {
        private Basket basket;

        [Given(@"empty basket")]
        public void GivenEmptyBasket()
        {
            basket = new Basket(TaxLocation.None, null);
        }
        
        [When(@"I add course to basket")]
        public void WhenIAddCourseToBasket()
        {
            basket.Add(new Course());
        }
        
        [Then(@"there should be (.*) item in basket")]
        public void ThenThereShouldBeItemInBasket(int expectedBasketCount)
        {
            basket.Count().ShouldEqual(expectedBasketCount);
        }
    }
}
