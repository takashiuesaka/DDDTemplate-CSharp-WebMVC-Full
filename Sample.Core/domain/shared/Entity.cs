using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
    internal abstract class Entity<T> : IEntity<T>
    {
        public Identity Identity { get; }

        public Entity(Identity identity)
        {
            this.Identity = identity;
        }

        public virtual bool SameIdentityAs(T other)
        {
            return this.Identity.SameValueAs((other as Entity<T>)?.Identity);
        }
    }
}
