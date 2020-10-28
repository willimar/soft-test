using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.CalculateInterest.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]/")]
    [ApiController]
    public class ShowmeTheCodeController: Controller
    {
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
