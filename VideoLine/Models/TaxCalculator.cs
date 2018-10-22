using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLine.Models
{
    internal class TaxCalculator
    {
        public decimal IncludeTaxPrice(decimal totalPrice, TaxLocation taxLocation)
        {
            if (taxLocation == TaxLocation.Pl)
                totalPrice = totalPrice * 1.23m;
            else if (taxLocation == TaxLocation.Usa)
                totalPrice = totalPrice * 1.1m;
            return totalPrice;
        }
    }
}