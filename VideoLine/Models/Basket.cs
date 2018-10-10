using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLine.Models
{
    public class Basket
    {
        private List<Course> _courses = new List<Course>();
        private TaxLocation taxLocation;
        private readonly IDateTimeProvider dateTimeProvider;

        public Basket(TaxLocation taxLocation, IDateTimeProvider dateTimeProvider)
        {
            this.taxLocation = taxLocation;
            this.dateTimeProvider = dateTimeProvider;
        }

        public int Count()
        {
            return _courses.Count;
        }

        public void Add(Course course)
        {
            if (course == null)
                throw new ArgumentNullException("course");

            _courses.Add(course);
        }

        public void Remove(Course course)
        {
            _courses.Remove(course);
        }

        public BasketSummary RenderSummary()
        {
            decimal totalPrice = _courses.Sum(c => c.NetPrice);
            TaxCalculator calculator = new TaxCalculator();
            totalPrice = calculator.IncludeTaxPrice(totalPrice, taxLocation);

            if (this.dateTimeProvider.Now.Hour >= 12 && this.dateTimeProvider.Now.Hour <= 14)
                totalPrice = totalPrice * 0.9m;

            return new BasketSummary()
            {
                Count = _courses.Count,
                Courses = _courses.ToArray(),
                TotalPrice = totalPrice
            };
        }
    }
}