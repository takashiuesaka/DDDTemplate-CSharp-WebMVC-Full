using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.persistence
{
    internal class DailyTimeRecordRepository : IDailyTimeRecordRepository
    {
        public IReadOnlyList<DailyTimeRecord> ListTimeRecording()
        {
            return new List<DailyTimeRecord>()
            {
                new DailyTimeRecord(
                    identity: new Identity(),
                    date: new Date(new DateTime(2021, 4, 1)),
                    startTime: new Time(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: new Time(new DateTime(2021,4,1,17, 30, 0)),
                    breakTime: new Duration(new TimeSpan(1, 0, 0)),
                    workTime: new Duration(new TimeSpan(7, 30, 0)),
                    overTime: new Duration(TimeSpan.Zero)),
                new DailyTimeRecord(
                    identity: new Identity(),
                    date: new Date(new DateTime(2021, 4, 2)),
                    startTime: new Time(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: new Time(new DateTime(2021,4,1,17, 30, 0)),
                    breakTime: new Duration(new TimeSpan(1, 0, 0)),
                    workTime: new Duration(new TimeSpan(7, 30, 0)),
                    overTime: new Duration(TimeSpan.Zero)),
                new DailyTimeRecord(
                    identity: new Identity(),
                    date: new Date(new DateTime(2021, 4, 3)),
                    startTime: new Time(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: new Time(new DateTime(2021, 4, 1, 18, 30, 0)),
                    breakTime: new Duration(new TimeSpan(1, 0, 0)),
                    workTime: new Duration(new TimeSpan(8, 30, 0)),
                    overTime: new Duration(new TimeSpan(1, 0, 0))),
            };
        }
    }
}
