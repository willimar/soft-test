using Willimar.Provider.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Willimar.Provider.Core.entities
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
    }
}
