using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.interfaces.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.interfaces.impl.modelConverter
{
    internal static class DailyTimeRecordConverter
    {
        public static IReadOnlyList<DailyTimeRecordDto> ToListDto(IReadOnlyList<DailyTimeRecord> listDailyTimeRecord)
        {
            var result = new List<DailyTimeRecordDto>(listDailyTimeRecord.Count);

            foreach (var dailyTimeRecord in listDailyTimeRecord)
            {
                result.Add(
                    new DailyTimeRecordDto(
                        id: dailyTimeRecord.Id.Id,
                        date: dailyTimeRecord.CalendarDate.DateTime,
                        startTime: dailyTimeRecord.StartTime.CalendarDateTime,
                        endTime: dailyTimeRecord.EndTime.CalendarDateTime,
                        breakTime: dailyTimeRecord.BreakTime,
                        workTime: dailyTimeRecord.WorkingHours,
                        overTime: dailyTimeRecord.OvertimeHours));
            }

            return result;
        }
    }
}
