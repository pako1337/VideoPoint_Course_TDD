using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLine.Models
{
    public class Basket
    {
        private int _basketCount = 0;

        public int Count()
        {
            return _basketCount;
        }

        public void Add(Course course)
        {
            _basketCount++;
        }

        public void Remove(Course course)
        {
            _basketCount--;
        }

        public BasketSummary RenderSummary()
        {
            return new BasketSummary();
        }
    }
}