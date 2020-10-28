using Soft.CalculateInterest.Domain.entities;
using Soft.CalculateInterest.Domain.interfaces;
using Soft.CalculateInterest.Domain.services;
using System;
using System.Threading.Tasks;

namespace Soft.CalculateInterest.Application
{
    public class CalculateInterestApplication
    {
        private readonly ICalculateInterestService _calculateInterestService;
        private readonly INavigator _jurosRateService;

        public CalculateInterestApplication(ICalculateInterestService calculateInterestService, INavigator jurosRateService)
        {
            this._calculateInterestService = calculateInterestService;
            this._jurosRateService = jurosRateService;
        }

        public async Task<decimal> Calculate(decimal initial, int months, string rateApi)
        {
            var rate = this._jurosRateService.Get(rateApi);

            var calculatein = new CalculateIn()
            {
                InitialValue = initial,
                Months = months,
                Rate = (decimal)rate
            };

            return await this._calculateInterestService.Execute(calculatein);
        }
    }
}
