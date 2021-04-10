using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.shared
{
    internal class Identity : IIdentity<Identity>
    {
        private Guid InnerId { get; }

        public string Id
        {
            get { return this.InnerId.ToString(); }
        }

        public Identity()
        {
            this.InnerId = Guid.NewGuid();
        }

        public Identity(string guidId)
        {
            this.InnerId = Guid.Parse(guidId);
        }

        public bool SameValueAs(Identity other)
        {
            return this.InnerId == other.InnerId;
        }
    }
}
