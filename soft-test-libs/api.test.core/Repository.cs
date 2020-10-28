using Willimar.Provider.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Willimar.Provider.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly IProvider<TEntity> _provider;

        public Repository(IProvider<TEntity> provider)
        {
            this._provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func)
        {
            return this._provider.DataSet.Where(func.Compile());
        }
    }
}
