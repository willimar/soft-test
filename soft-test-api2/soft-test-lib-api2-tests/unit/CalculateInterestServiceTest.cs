using FluentAssertions;
using Soft.CalculateInterest.Domain.entities;
using Soft.CalculateInterest.Domain.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Soft.CalculateInterest.Test.unit
{
    public class CalculateInterestServiceTest
    {
        public CalculateInterestServiceTest()
        {

        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(0, 0, 1, 0)]
        [InlineData(100, 5, 0.01, 105.10)]
        public void CalculateInterestService_Execute(decimal initialValue, int months, decimal rate, decimal calculated)
        {
            var service = new CalculateInterestService();
            var value = new CalculateIn()
            {
                InitialValue = initialValue,
                Months = months,
                Rate = rate
            };

            var result = service.Execute(value).Result;

            result.Should().Be(calculated);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void CalculateInterestService_Value_Less_Zero(decimal initialValue, int months, decimal rate)
        {
            var service = new CalculateInterestService();
            var value = new CalculateIn()
            {
                InitialValue = initialValue,
                Months = months,
                Rate = rate
            };

            Action action = () => service.Execute(value).Wait();

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
