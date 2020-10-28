using Soft.CalculateInterest.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Soft.CalculateInterest.Domain.interfaces
{
    public interface ICalculateInterestService
    {
        Task<decimal> Execute(CalculateIn calculateIn);
    }
}
