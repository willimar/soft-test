using FluentAssertions;
using Moq;
using Soft.InterestRate.Domain.entities;
using Soft.InterestRate.Domain.Services.Concrete;
using Soft.InterestRate.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Soft.InterestRate.Domain.tests.unitario
{
    public class InterestRateServiceTest
    {

        [Theory]
        [InlineData(0.01)]
        [InlineData(0.00)]
        [InlineData(-0.01)]
        [InlineData(1.01)]
        [InlineData(-1.01)]
        [InlineData(0.0000001)]
        [InlineData(-0.0000001)]
        public async Task InterestRateController_CheckResultValue(decimal value)
        {
            // Arrange - Preparando o ambiente para teste
            var mock = new Mock<InterestRateEntity>();            
            IService<InterestRateEntity> service = new InterestRateService();

            var entity = mock.Object;
            entity.Value = value;

            // Act - Executando o teste
            var result = await service.Get(entity);

            // Assert - Validando se o resultado foi o esperado
            result.Should().Be(value);
        }
    }
}
