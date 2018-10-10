using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLine.Models
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}