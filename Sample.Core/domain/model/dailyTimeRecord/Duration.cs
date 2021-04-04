using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class Duration : ValueObject<Duration>
    {
        public TimeSpan TimeSpan { get; }

        public Duration(TimeSpan timeSpan)
        {
            this.TimeSpan = timeSpan;
        }

        public override bool SameValueAs(Duration other)
        {
            return this.TimeSpan == other.TimeSpan;
        }
    }
}
