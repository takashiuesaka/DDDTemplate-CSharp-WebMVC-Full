using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
    interface IEntity<T>
    {
        bool SameIdentityAs(T other);
    }
}
