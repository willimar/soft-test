using Soft.InterestRate.Domain.entities;
using Soft.InterestRate.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Soft.InterestRate.Domain.Services.Concrete
{
    public class InterestRateService : IService<InterestRateEntity>
    {
        public async Task<decimal> Get(InterestRateEntity InterestRate)
        {
            return 0.01M;
        }
    }
}
