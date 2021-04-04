using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
     internal interface IValueObject<T>
    {
        public bool SameValueAs(T other);
    }
}
