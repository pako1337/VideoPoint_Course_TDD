using System.Collections.Generic;

namespace VideoLine.Models
{
    public struct BasketSummary
    {
        public int Count { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}