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

        public Basket(TaxLocation taxLocation)
        {
            this.taxLocation = taxLocation;
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

            return new BasketSummary()
            {
                Count = _courses.Count,
                Courses = _courses.ToArray(),
                TotalPrice = totalPrice
            };
        }
    }
}