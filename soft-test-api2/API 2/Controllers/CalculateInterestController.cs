using Microsoft.AspNetCore.Mvc;
using soft.test.lib.api2.entities;
using soft.test.lib.api2.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soft.test.api.two.Controllers
{
    [Produces("application/json")]
    [Route("api/CalcularJuros/")]
    [ApiController]
    public class CalculateInterestController
    {
        private readonly CalculateInterestService _calculateInterestService;
        private readonly JurosRateService _jurosRateService;

        public CalculateInterestController(CalculateInterestService calculateInterestService, JurosRateService jurosRateService)
        {
            this._calculateInterestService = calculateInterestService;
            this._jurosRateService = jurosRateService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public decimal Get([FromQuery]decimal valorInicial, [FromQuery] int meses)
        {
            var rate = this._jurosRateService.Get(Program.RateApi);

            var calculatein = new CalculateIn()
            {
                InitialValue = valorInicial,
                Months = meses,
                Rate = (decimal)rate
            };

            return this._calculateInterestService.Execute(calculatein);
        }
    }
}
