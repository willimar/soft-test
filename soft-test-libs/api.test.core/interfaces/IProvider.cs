using System;
using System.Collections.Generic;
using System.Text;

namespace Willimar.Provider.Core.interfaces
{
    public interface IProvider<TEntity> where TEntity : IEntity
    {
        List<TEntity> DataSet { get; }
    }
}
