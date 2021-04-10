using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class Time : ValueObject<Time>
    {
        public DateTime DateTime { get; }

        public Time(string time)
        {
            this.DateTime = DateTime.Parse(time);
        }

        public Time(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        public override bool SameValueAs(Time other)
        {
            return this.DateTime == other.DateTime;
        }

    }
}
