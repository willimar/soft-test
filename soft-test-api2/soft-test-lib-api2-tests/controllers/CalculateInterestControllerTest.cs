using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using soft.test.api.two;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace soft.test.lib.api2.tests.controllers
{
    public class CalculateInterestControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CalculateInterestControllerTest(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }

        [Theory]
        [InlineData(@"/api/CalcularJuros?valorInicial=-100.00&meses=5", "-105.1")]
        [InlineData(@"/api/CalcularJuros?valorInicial=-100.00&meses=0", "-100")]
        [InlineData(@"/api/CalcularJuros?valorInicial=-100.00&meses=3", "-103.03")]
        [InlineData(@"/api/CalcularJuros?valorInicial=0.00&meses=5", "0")]
        [InlineData(@"/api/CalcularJuros?valorInicial=0.01&meses=5", "0.01")]
        [InlineData(@"/api/CalcularJuros?valorInicial=25.00&meses=3", "25.75")]
        [InlineData(@"/api/CalcularJuros?valorInicial=32.00&meses=5", "33.63")]
        [InlineData(@"/api/CalcularJuros?valorInicial=45.00&meses=5", "47.29")]
        [InlineData(@"/api/CalcularJuros?valorInicial=100.00&meses=5", "105.1")]
        [InlineData(@"/api/CalcularJuros?valorInicial=100.00&meses=2", "102.01")]
        [InlineData(@"/api/CalcularJuros?valorInicial=100.00&meses=8", "108.28")]
        [InlineData(@"/api/CalcularJuros?valorInicial=100.00&meses=0", "100")]
        [InlineData(@"/api/CalcularJuros?valorInicial=5744.25&meses=5", "6037.26")]
        public async Task CalculateInterestController_CalcularJuros(string url, string returnValue)
        {
            var client = this._factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            response.Content.ReadAsStringAsync().Result.Should().Be(returnValue);
        }
    }
}
