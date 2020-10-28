using Soft.CalculateInterest.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soft.CalculateInterest.Domain.interfaces
{
    public interface ICalculateInterestService
    {
        decimal Execute(CalculateIn calculateIn);
    }
}
