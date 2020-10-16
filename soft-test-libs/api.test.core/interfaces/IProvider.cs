using System;
using System.Collections.Generic;
using System.Text;

namespace api.test.core.interfaces
{
    public interface IProvider<TEntity> where TEntity : IEntity
    {
        List<TEntity> DataSet { get; }
    }
}
