using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
    internal abstract class Entity<T> : IEntity<T>
    {
        public Identity Id { get; protected set; }

        public Entity(Identity id)
        {
            this.Id = id;
        }

        public virtual bool SameIdentityAs(T other)
        {
            return this.Id.SameValueAs((other as Entity<T>)?.Id);
        }
    }
}
