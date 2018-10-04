using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            basket = new Basket();
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
            var basket = new Basket();

            var course = new Course() { NetPrice = 10.0m };
            basket.Add(course);

            var summary = basket.RenderSummary();

            summary.TotalPrice.ShouldEqual(10.0m);
        }
    }
}
