using api.test.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.test.core.entities
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
    }
}
