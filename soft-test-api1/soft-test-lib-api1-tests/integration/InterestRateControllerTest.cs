using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using soft.test.api.one;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace soft.test.lib.api1.tests.integration
{
    public class InterestRateControllerTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public InterestRateControllerTest(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }

        [Theory]
        [InlineData("/api/TaxaJuros")]
        public async Task InterestRateController_CheckResultValue(string url)
        {
            var client = this._factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            response.Content.ReadAsStringAsync().Result.Should().Be("0.01");
        }
    }
}
