using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class DailyTimeRecord : Entity<DailyTimeRecord>
    {

        public DailyTimeRecord(Identity identity, Date date, Time startTime, Time endTime, Duration breakTime, Duration workTime, Duration overTime) : base(identity)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            BreakTime = breakTime;
            WorkTime = workTime;
            OverTime = overTime;
        }

        public Date Date { get; }

        public Time StartTime { get; }

        public Time EndTime { get; }

        public Duration BreakTime { get; }

        public Duration WorkTime { get; }

        public Duration OverTime { get; }
    }
}
