using Microsoft.AspNetCore.Mvc;
using Soft.CalculateInterest.Application;
using Soft.CalculateInterest.Domain.entities;
using Soft.CalculateInterest.Domain.services;
using System;
using System.Threading.Tasks;

namespace Soft.CalculateInterest.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/CalcularJuros/")]
    [ApiController]
    public class CalculateInterestController
    {
        private readonly CalculateInterestApplication _calculateInterestApplication;

        public CalculateInterestController(CalculateInterestApplication calculateInterestApplication)
        {
            this._calculateInterestApplication = calculateInterestApplication;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<decimal> Get([FromQuery]decimal? valorInicial, [FromQuery] int? meses)
        {
            var inicial = valorInicial ?? throw new ArgumentNullException(nameof(valorInicial));
            var moths = meses ?? throw new ArgumentNullException(nameof(meses));

            return await this._calculateInterestApplication.Calculate(inicial, moths, Program.RateApi);
        }
    }
}
