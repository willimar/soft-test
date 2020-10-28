using System;
using System.Collections.Generic;
using System.Text;

namespace Soft.CalculateInterest.Domain.entities
{
    public class CalculateIn
    {
        public decimal InitialValue { get; set; }
        public decimal Rate { get; set; }
        public int Months { get; set; }
    }
}
