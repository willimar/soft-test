using api.test.core.interfaces;
using soft.test.lib.api1.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soft.test.api.one.providers
{
    internal class InterestRateProvider : IProvider<InterestRate>
    {
        public List<InterestRate> DataSet { get; private set; }

        public InterestRateProvider()
        {
            this.DataSet = new List<InterestRate>() { new InterestRate() { Id = Guid.NewGuid(), Value = 0.01 } };
        }
    }
}
