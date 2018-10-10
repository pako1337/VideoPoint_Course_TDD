using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Should;
using VideoLine.Models;

namespace VideoLine.Tests
{
    public class BasketTests
    {
        private Basket basket;

        [SetUp]
        public void Setup()
        {
            basket = new Basket(TaxLocation.None, new DateTimeProvider());
        }

        [TearDown]
        public void Teardown()
        {

        }

        [OneTimeSetUp]
        public void FixtureSetup()
        {

        }

        [OneTimeTearDown]
        public void FixtureTeardown()
        {

        }

        [Test]
        public void ShouldCreateEmptyBasket()
        {
            Assert.AreEqual(0, basket.Count());
        }

        [Test]
        public void ShouldReturnBasketCountWhenOneCourseAdded()
        {
            basket.Add(new Course());

            Assert.AreEqual(1, basket.Count());
        }

        [Test]
        public void ShouldRemoveCourseFromBasketAndDecreaseCount()
        {
            Course course = new Course();
            basket.Add(course);
            basket.Remove(course);

            Assert.AreEqual(0, basket.Count());
        }

        [Test]
        public void ShouldReturnSummaryWithCourses()
        {
            basket.Add(new Course() { Title = "Test 1" });

            var summary = basket.RenderSummary();

            Assert.AreEqual(1, summary.Count);
            Assert.AreEqual("Test 1", summary.Courses.First().Title);
        }

        [Test]
        public void ShouldReturnSummaryWithoutCoursesAfterCourseRemoval()
        {
            Course course = new Course() { Title = "Test 1" };
            basket.Add(course);
            basket.Remove(course);

            var summary = basket.RenderSummary();

            Assert.AreEqual(0, summary.Count);
            Assert.IsEmpty(summary.Courses);
        }

        [Test]
        public void ShouldNotAcceptNullAsCourse()
        {
            Assert.Throws<ArgumentNullException>(() => basket.Add(null));
        }

        [Test]
        public void ShouldReturnFullBasketPrice()
        {
            var course = new Course() { NetPrice = 10.0m };
            basket.Add(course);

            var summary = basket.RenderSummary();

            summary.TotalPrice.ShouldEqual(10.0m);
        }

        [Test]
        public void ShouldReturnFullBasketPriceWithPlTaxIncluded()
        {
            var basket = new Basket(TaxLocation.Pl, new DateTimeProvider());

            var course = new Course() { NetPrice = 10.0m };
            basket.Add(course);

            var summary = basket.RenderSummary();

            summary.TotalPrice.ShouldEqual(12.3m);
        }

        [Test]
        public void ShouldLowerPrices10PercentBetweenNoonAnd2Pm()
        {
            var timeProvider = new Mock<IDateTimeProvider>();
            var basket = new Basket(TaxLocation.None, timeProvider.Object);

            var course = new Course() { NetPrice = 10m };
            basket.Add(course);

            timeProvider.Setup(t => t.Now).Returns(new DateTime(2018, 10, 10, 13, 0, 0));

            var summary = basket.RenderSummary();

            summary.TotalPrice.ShouldEqual(9m);
        }
    }
}
