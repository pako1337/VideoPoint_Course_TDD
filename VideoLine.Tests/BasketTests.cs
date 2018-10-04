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

        [Test]
        public void ShouldRemoveCourseFromBasketAndDecreaseCount()
        {
            var basket = new Basket();

            Course course = new Course();
            basket.Add(course);
            basket.Remove(course);

            Assert.AreEqual(0, basket.Count());
        }

        [Test]
        public void ShouldReturnSummaryWithCourses()
        {
            var basket = new Basket();

            basket.Add(new Course() { Title = "Test 1" });

            var summary = basket.RenderSummary();

            Assert.AreEqual(1, summary.Count);
            Assert.AreEqual("Test 1", summary.Courses.First().Title);
        }

        [Test]
        public void ShouldReturnSummaryWithoutCoursesAfterCourseRemoval()
        {
            var basket = new Basket();

            Course course = new Course() { Title = "Test 1" };
            basket.Add(course);
            basket.Remove(course);

            var summary = basket.RenderSummary();

            Assert.AreEqual(0, summary.Count);
            Assert.IsEmpty(summary.Courses);

            summary.Count.ShouldEqual(1);
            summary.Courses.ShouldBeEmpty();
        }
    }
}
