using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLine.Models
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
