using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.interfaces.dto
{
    public class DailyTimeRecordDto
    {
        public DailyTimeRecordDto(string id, DateTime date, DateTime startTime, DateTime endTime, TimeSpan breakTime, TimeSpan workTime, TimeSpan overTime)
        {
            Id = id;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            BreakTime = breakTime;
            Worktime = workTime;
            Overtime = overTime;
        }

        public string Id { get; }

        public DateTime Date { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public TimeSpan BreakTime { get; }

        public TimeSpan Worktime { get; }

        public TimeSpan Overtime { get; }
    }
}
