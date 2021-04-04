using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class Date : ValueObject<Date>
    {
        public DateTime DateTime { get; }

        public Date(DateTime date)
        {
            this.DateTime = date;
        }

        public override bool SameValueAs(Date other)
        {
            return this.DateTime.Date == other.DateTime.Date;
        }
    }
}
