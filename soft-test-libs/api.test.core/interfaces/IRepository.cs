using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace api.test.core.interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func);
    }
}
