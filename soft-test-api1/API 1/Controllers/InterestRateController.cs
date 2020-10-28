using Microsoft.AspNetCore.Mvc;
using Soft.InterestRate.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Soft.InterestRate.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/TaxaJuros/")]
    [ApiController]
    public class InterestRateController
    {
        private readonly IService<Domain.entities.InterestRateEntity> _service;

        public InterestRateController(IService<Domain.entities.InterestRateEntity> service)
        {
            this._service = service;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<decimal> Get([FromServices] Domain.entities.InterestRateEntity value)
        {
            return await this._service.Get(value);
        }
    }
}
