using api.test.core.interfaces;
using Microsoft.AspNetCore.Mvc;
using soft.test.lib.api1.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace soft.test.api.one.Controllers
{
    [Produces("application/json")]
    [Route("api/TaxaJuros/")]
    [ApiController]
    public class InterestRateController
    {
        private readonly IRepository<InterestRate> _repository;

        public InterestRateController(IRepository<InterestRate> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public double Get()
        {
            // ATENÇÃO
            // A criação do repositório é somente para demonstrar a utilização de DDD, mas como o valor é sempre o mesmo seria desnecessário.
            // um código como este jamais seria escrito em ambiente mutável, pois haveria a possibilidade de se retornar algo diferente no provider.
            var result = this._repository.GetData(x => true).First().Value;
            return result;
        }
    }
}
