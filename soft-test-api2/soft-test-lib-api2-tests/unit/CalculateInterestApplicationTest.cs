using FluentAssertions;
using Moq;
using Soft.CalculateInterest.Application;
using Soft.CalculateInterest.Domain.interfaces;
using Soft.CalculateInterest.Domain.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Soft.CalculateInterest.Test.unit
{
    public class CalculateInterestApplicationTest
    {
        private readonly Mock<INavigator> _navigatorMock;
        private readonly ICalculateInterestService _service;
        private readonly CalculateInterestApplication _application;

        public CalculateInterestApplicationTest()
        {
            this._navigatorMock = new Mock<INavigator>();
            this._service = new CalculateInterestService();
            this._application = new CalculateInterestApplication(this._service, this._navigatorMock.Object);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(0, 0, 1, 0)]
        [InlineData(100, 5, 0.01, 105.10)]
        public void CalculateInterestService_Execute(decimal initialValue, int months, decimal rate, decimal calculated)
        {
            this._navigatorMock.Setup(get => get.Get("")).Returns(rate);

            var result = this._application.Calculate(initialValue, months, "");

            result.Should().Be(calculated);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void CalculateInterestService_Value_Less_Zero(decimal initialValue, int months, decimal rate)
        {
            this._navigatorMock.Setup(get => get.Get("")).Returns(rate);

            Action action = () => this._application.Calculate(initialValue, months, "");

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
