using Soft.CalculateInterest.Domain.entities;
using Soft.CalculateInterest.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Soft.CalculateInterest.Domain.services
{
    public class CalculateInterestService: ICalculateInterestService
    {
        public CalculateInterestService()
        {
            
        }

        public async Task<decimal> Execute(CalculateIn calculateIn)
        {
            if (calculateIn.InitialValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calculateIn.InitialValue));
            }

            if (calculateIn.Months < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calculateIn.Months));
            }

            if (calculateIn.Rate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calculateIn.Rate));
            }

            var preCalc = Math.Pow((double)(1 + calculateIn.Rate), calculateIn.Months);
            var total = (double)calculateIn.InitialValue * preCalc;

            return await Task<decimal>.Run(() => { return (decimal)Math.Truncate(100.00 * total) / 100; }); 
        }
    }
}
