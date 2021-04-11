using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Infrastructure.persistence
{
    internal class DailyTimeRecordRepository : IDailyTimeRecordRepository
    {
        #region sampledata
        private List<DailyTimeRecord> listSampleData = new List<DailyTimeRecord>()
        {
                new DailyTimeRecord(
                    identity: new Identity("75A208B6-C168-4A41-9F81-38FA0FBF4074"),
                    calendarDate: new CalendarDate(new DateTime(2021, 4, 1)),
                    startTime: Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: Time.Create(new DateTime(2021,4,1,17, 30, 0)),
                    breakTime: new TimeSpan(1, 0, 0),
                    workingHours: new TimeSpan(7, 30, 0),
                    overtimeHours: TimeSpan.Zero),
                new DailyTimeRecord(
                    identity: new Identity("EADF198A-809F-4ED9-80AE-C40EF6164AA8"),
                    calendarDate: new CalendarDate(new DateTime(2021, 4, 2)),
                    startTime: Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: Time.Create(new DateTime(2021,4,1,17, 30, 0)),
                    breakTime: new TimeSpan(1, 0, 0),
                    workingHours: new TimeSpan(7, 30, 0),
                    overtimeHours: TimeSpan.Zero),
                new DailyTimeRecord(
                    identity: new Identity("AD81BA39-2883-4A1A-B992-9B3B4ABF64B4"),
                    calendarDate: new CalendarDate(new DateTime(2021, 4, 3)),
                    startTime: Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)),
                    endTime: Time.Create(new DateTime(2021, 4, 1, 18, 30, 0)),
                    breakTime: new TimeSpan(1, 0, 0),
                    workingHours: new TimeSpan(8, 30, 0),
                    overtimeHours: new TimeSpan(1, 0, 0)),
        };
        #endregion

        public DailyTimeRecord GetById(Identity id)
        {
            return listSampleData.Single(m => m.Id.SameValueAs(id));
        }

        public IReadOnlyList<DailyTimeRecord> ListTimeRecording()
        {
            return listSampleData;
        }

        public void Update(DailyTimeRecord dailyTimeRecord)
        {
            for (int i = 0; i < listSampleData.Count; i++)
            {
                if (listSampleData[i].SameIdentityAs(dailyTimeRecord))
                {
                    listSampleData[i] = dailyTimeRecord;
                    break;
                }
            }
        }
    }
}
