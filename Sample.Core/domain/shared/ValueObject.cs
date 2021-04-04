using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
    internal abstract class ValueObject<T> : IValueObject<T>
    {
        public abstract bool SameValueAs(T other);
    }
}