using soft.test.lib.api2.entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace soft.test.lib.api2.services
{
    public class CalculateInterestService
    {
        public CalculateInterestService()
        {
            
        }

        public decimal Execute(CalculateIn calculateIn)
        {
            var preCalc = Math.Pow((double)(1 + calculateIn.Rate), calculateIn.Months);
            var total = (double)calculateIn.InitialValue * preCalc;
            return (decimal)Math.Truncate(100.00 * total) / 100;
        }
    }
}
