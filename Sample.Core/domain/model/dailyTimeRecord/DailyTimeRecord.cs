using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class DailyTimeRecord : Entity<DailyTimeRecord>
    {

        public DailyTimeRecord(Identity identity, DateTime date, DateTime startTime, DateTime endTime, TimeSpan breakTime, TimeSpan workTime, TimeSpan overTime) : base(identity)
        {
            base.Id = identity;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            BreakTime = breakTime;
            WorkTime = workTime;
            OverTime = overTime;
        }

        public DailyTimeRecord UpdateStartTime(Time startTime)
        {
            Duration newWorkTime = startTime - EndTime;
            return new DailyTimeRecord(
                base.Id, Date, startTime,
                EndTime, BreakTime, WorkTime,
                );
        }

        public DateTime Date { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public TimeSpan BreakTime { get; }

        public TimeSpan WorkTime { get; }

        public TimeSpan OverTime { get; }
    }
}
