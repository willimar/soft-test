using api.test.core;
using api.test.core.interfaces;
using soft.test.lib.api1.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace soft.test.lib.api1.repositories
{
    /// <summary>
    /// Essa classe é desnecessária visto que não implementa nenhuma exclusividade, mas queria demonstrar herança no processo de ddd. 
    /// Criar essa classe facilita teses de integração e inversão de controle. 
    /// </summary>
    public class InterestRateRepository : Repository<InterestRate>
    {
        public InterestRateRepository(IProvider<InterestRate> provider) : base(provider)
        {
        }
    }
}
