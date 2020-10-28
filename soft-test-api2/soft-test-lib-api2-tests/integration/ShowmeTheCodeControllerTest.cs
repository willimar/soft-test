using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Soft.CalculateInterest.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Soft.CalculateInterest.Test.integration
{
    public class ShowmeTheCodeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ShowmeTheCodeControllerTest(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }

        [Theory]
        [InlineData(@"/api/ShowmeTheCode")]
        public async Task ShowmeTheCodeController_Check_Available(string url)
        {
            var client = this._factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
