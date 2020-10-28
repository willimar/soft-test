using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Soft.InterestRate.Domain.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<decimal> Get(TEntity entity);
    }
}
